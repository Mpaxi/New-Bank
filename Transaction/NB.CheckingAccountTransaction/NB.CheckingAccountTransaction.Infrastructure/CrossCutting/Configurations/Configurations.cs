using Microsoft.Extensions.Configuration;

namespace NB.CheckingAccountTransaction.Infrastructure.CrossCutting.Configurations
{
    public class Configurations
    {
        
        private static Configurations _instance;
        private static readonly object _lock = new object();

        public static Configurations Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Configurations();
                        }
                    }
                }
                return _instance;
            }
        }

        //private Configurations()
        //{
        //    try
        //    {
        //        var cb = new ConfigurationBuilder()
        //            .SetBasePath(Directory.GetCurrentDirectory())
        //            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        //        _configuration = cb.Build();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        //public string ConnectionStrings
        //{
        //    get
        //    {
        //        return _configuration.GetSection("ConnectionStrings").GetValue<string>("DefaultConnection");
        //    }
        //}

        //public RedisConfig RedisConfig
        //{
        //    get
        //    {
        //        return _configuration.GetSection("RedisConfig").Get<RedisConfig>();
        //    }
        //}

        //public RabbitConfig RabbitConfig
        //{
        //    get
        //    {
        //        return _configuration.GetSection("RabbitConfig").Get<RabbitConfig>();
        //    }
        //}
    }
}
