using MassTransit;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NB.CheckingAccountTransaction.API.Helpers;
using NB.CheckingAccountTransaction.Domain.Consumer;
using NB.CheckingAccountTransaction.Domain.Contract;
using NB.CheckingAccountTransaction.Domain.Implementation;
using NB.CheckingAccountTransaction.Repository.Context;
using NB.CheckingAccountTransaction.Repository.Implementation;
using RedLockNet;
using RedLockNet.SERedis;
using RedLockNet.SERedis.Configuration;
using StackExchange.Redis;
using System.Collections.Generic;

namespace NB.CheckingAccountTransaction.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var DataBaseSection = Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
            var RedisSection = Configuration.GetSection("ConnectionStrings:RedisConnection").Value;
            var RabbitMQHost = Configuration.GetSection("RabbitMQ:Host").Value;
            var RabbitMQPort = ushort.Parse(Configuration.GetSection("RabbitMQ:Port").Value);
            var RabbitMQVhost = Configuration.GetSection("RabbitMQ:Vhost").Value;
            var RabbitMQUser = Configuration.GetSection("RabbitMQ:User").Value;
            var RabbitMQPassword = Configuration.GetSection("RabbitMQ:Password").Value;

            //#if DEBUG
            //            var DataBaseSection = Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
            //            var RedisSection = Configuration.GetSection("ConnectionStrings:RedisConnection").Value;
            //            var RabbitMQHost = Configuration.GetSection("RabbitMQ:Host").Value;
            //            var RabbitMQPort = ushort.Parse(Configuration.GetSection("RabbitMQ:Port").Value);
            //            var RabbitMQVhost = Configuration.GetSection("RabbitMQ:Vhost").Value;
            //            var RabbitMQUser = Configuration.GetSection("RabbitMQ:User").Value;
            //            var RabbitMQPassword = Configuration.GetSection("RabbitMQ:Password").Value;
            //#else
            //            var Hostname = Configuration["SQLSERVER_HOST"];
            //            var User = Configuration["SQLSERVER_USER"];
            //            var Password = Configuration["SQLSERVER_PASSWORD"];
            //            var Catalog = Configuration["SQLSERVER_CATALOG"];

            //            var DataBaseSection = $"Data Source={Hostname};Initial Catalog={Catalog};User ID={User};Password={Password};";

            //            var RedisSection = Configuration["REDIS_HOST"];
            //            var RabbitMQHost = Configuration["RABBITMQ_HOST"];
            //            var RabbitMQPort = ushort.Parse(Configuration["RABBITMQ_PORT"]);
            //            var RabbitMQVhost = Configuration["RABBITMQ_VHOST"];
            //            var RabbitMQUser = Configuration["RABBITMQ_USER"];
            //            var RabbitMQPassword = Configuration["RABBITMQ_PASSWORD"];
            //#endif


            services.AddScoped<ICheckingAccountTransactionRepository, CheckingAccountTransactionRepository>();
            services.AddScoped<ICheckingAccountTransactionStatusRepository, CheckingAccountTransactionStatusRepository>();
            services.AddScoped<ICheckingAccountTransactionTypeRepository, CheckingAccountTransactionTypeRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<ICheckingAccountRepository, CheckingAccountRepository>();

            services.AddScoped<ICheckingAccountTransactionDomain, CheckingAccountTransactionDomain>();
            services.AddScoped<ICheckingAccountDomain, CheckingAccountDomain>();

            services.AddSingleton<IPublishEndpoint>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<ISendEndpointProvider>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<IHostedService, MassTransitHostedService>();
            var cm = ConnectionMultiplexer.Connect("10.1.10.133:6378");

            services.AddSingleton<IConnectionMultiplexer>(cm);

            services.AddSingleton<IDistributedLockFactory>(RedLockFactory.Create(new List<RedLockMultiplexer> { cm }));

            services.AddDbContextPool<DataContext>(options =>
                options.UseSqlServer(DataBaseSection, b => b.MigrationsAssembly("NB.CheckingAccountTransaction.API"))
                .RalmsExtendFunctions()

            );

            services.AddMassTransit(x =>
            {
                // add the consumer, for LoadFrom
                x.AddConsumer<AddInternalTransaction>();
                x.AddConsumer<AddCreditCardTransaction>();
                x.AddConsumer<CheckingAccountCreated>();
            });

            services.AddSingleton(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(RabbitMQHost, RabbitMQPort, RabbitMQVhost, h =>
                 {
                     h.Username(RabbitMQUser);
                     h.Password(RabbitMQPassword);
                 });

                cfg.ReceiveEndpoint(host, "CheckingAccount_Transactione_Queue", e =>
                {
                    //e.PrefetchCount = 1000;
                    e.LoadFrom(provider);

                });
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
            app.UseWelcomePage();
        }
    }
}
