using CheckAccountTransaction.API.Consumer;
using CheckAccountTransaction.API.Helper;
using GreenPipes;
using MassTransit;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NB.SupportPackages.Entities.Command.CheckingAccountTransaction;

namespace CheckAccountTransaction.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var RabbitMQHost = Configuration.GetSection("RabbitMQ:Host").Value;
            var RabbitMQPort = ushort.Parse(Configuration.GetSection("RabbitMQ:Port").Value);
            var RabbitMQVhost = Configuration.GetSection("RabbitMQ:Vhost").Value;
            var RabbitMQUser = Configuration.GetSection("RabbitMQ:User").Value;
            var RabbitMQPassword = Configuration.GetSection("RabbitMQ:Password").Value;

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IPublishEndpoint>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<ISendEndpointProvider>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());
            services.AddScoped(provider => provider.GetRequiredService<IBus>().CreateRequestClient<AddCheckingAccountTransactionCommand>());
            services.AddSingleton<IHostedService, MassTransitHostedService>();

            services.AddScoped<IService, Service>();

            services.AddSingleton(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(RabbitMQHost, RabbitMQPort, RabbitMQVhost, h =>
                {
                    h.Username(RabbitMQUser);
                    h.Password(RabbitMQPassword);
                });

                //cfg.ReceiveEndpoint(host, "CheckingAccount_Transactione_Queue", e =>
                //{
                //    e.PrefetchCount = 16;
                //    e.UseMessageRetry(x => x.Interval(2, 100));
                //    //e.PrefetchCount = 1000;
                //    //e.LoadFrom(provider);
                //    EndpointConvention.Map<AddCheckingAccountTransactionCommand>(e.InputAddress);

                //});
            }));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseMvc();
        }
    }
}
