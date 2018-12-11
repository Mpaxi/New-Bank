using Autofac;
using Autofac.Extensions.DependencyInjection;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NB.CheckingAccount.API.Helpers;
using NB.CheckingAccount.Domain.Consumers;
using NB.CheckingAccount.Domain.Context;
using NB.CheckingAccount.Domain.Contract;
using NB.CheckingAccount.Domain.Implementation;
using NB.CheckingAccount.Repository.Implementation;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace NB.CheckingAccount.API
{
    ///TODO MOver para um Nuget
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer Container { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICheckingAccountStatusRepository, CheckingAccountStatusRepository>();
            services.AddTransient<ICheckingAccountRepository, CheckingAccountRepository>();
            services.AddTransient<ICheckingAccountTransactionRepository, CheckingAccountTransactionRepository>();
            services.AddTransient<ICheckingAccountTransactionStatusRepository, CheckingAccountTransactionStatusRepository>();
            services.AddTransient<ICheckingAccountTransactionTypeRepository, CheckingAccountTransactionTypeRepository>();
            services.AddTransient<ICurrencyRepository, CurrencyRepository>();
            services.AddTransient<ICheckingAccountDomain, CheckingAccountDomain>();

            var configurationSection = Configuration.GetSection("ConnectionStrings:DefaultConnection");


            services.AddDbContextPool<DataContext>(options =>
                options.UseSqlServer(configurationSection.Value, b => b.MigrationsAssembly("NB.CheckingAccount.API"))
                .RalmsExtendFunctions()

            );


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IHostedService, MassTransitHostedService>();

            var builder = new ContainerBuilder();
            builder.RegisterType<MyConsumer>();


            builder.Register(c =>
            {
                return Bus.Factory.CreateUsingRabbitMq(sbc =>
                        sbc.Host("localhost", "/", h =>
                        {
                            h.Username("guest");
                            h.Password("guest");
                        }).
                        ConnectReceiveEndpoint("CheckingAccount_queue", e =>
                        {
                            e.LoadFrom(c);
                        })
                    );

            })
            .As<IBusControl>()
            .As<IPublishEndpoint>()
            .SingleInstance();

            builder.Populate(services);
            Container = builder.Build();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.Formatting = new Newtonsoft.Json.Formatting();
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                // options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });



            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(Container);


        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

            });


            app.UseMvc();

        }
    }
}
