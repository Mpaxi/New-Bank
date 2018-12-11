using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace NB.CheckingAccount.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                .UseKestrel(
                //options =>
                //{
                //    options.Listen(IPAddress.Loopback, 5000);  // http:localhost:5000
                //    options.Listen(IPAddress.Any, 80);         // http:*:80
                //    options.Listen(IPAddress.Loopback, 443, listenOptions =>
                //    {
                //        listenOptions.UseHttps("certificate.pfx", "password");
                //    });
                //}
                )
                .UseUrls("http://*:80", "https://*:443")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>();
    }
}
