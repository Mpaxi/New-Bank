using Autofac;
using Autofac.Extensions.DependencyInjection;
using MassTransit;
using MassTransit.Util;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NB.Registration.Domain.Contract;
using NB.Registration.Domain.Implementation;
using NB.Registration.Domain.Mediator;
using NB.Registration.Repository.Context;
using NB.Registration.Repository.Implementation;
using Newtonsoft.Json.Serialization;
using RabbitMQ.Client;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace NB.Registration.API
{
    ///TODO MOver para um Nuget
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {


            services.AddTransient<IPhysicalPersonDomain, PhysicalPersonDomain>();
            services.AddTransient<IPhysicalPersonRepository, PhysicalPersonRepository>();


            var configurationSection = Configuration.GetSection("ConnectionStrings:DefaultConnection");


            services.AddDbContextPool<DataContext>(options =>
                options.UseSqlServer(configurationSection.Value, b => b.MigrationsAssembly("NB.Registration.API"))
                .RalmsExtendFunctions()

            );

            services.AddMediatR();

            // if you have handlers/events in other assemblies
            services.AddMediatR(typeof(AddPhysicalPersonHandler).Assembly,
                                typeof(GetPhysicalPersonHandler).Assembly);


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "NB.Registration.API", Version = "v1" });
            });

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.Formatting = new Newtonsoft.Json.Formatting();
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                // options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            var builder = new ContainerBuilder();
            builder.Register(c =>
            {
                return Bus.Factory.CreateUsingRabbitMq(sbc =>
                {
                    sbc.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    sbc.ExchangeType = ExchangeType.Fanout;
                });
            })
                .As<IBusControl>()
                .As<IBus>()
                .As<IPublishEndpoint>()
                .SingleInstance();

            builder.Populate(services);
            ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(ApplicationContainer);
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NB Registration FP API V1");

            });

            //app.UseResponseCompression();

            app.UseMvc();

            var bus = ApplicationContainer.Resolve<IBusControl>();
            var busHandle = TaskUtil.Await(() => bus.StartAsync());
            lifetime.ApplicationStopping.Register(() => busHandle.Stop());
        }
    }
}
