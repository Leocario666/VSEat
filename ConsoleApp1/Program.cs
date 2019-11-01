using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using DTO;
using BLL;
using DAL;

namespace ConsoleApp1
{
    class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();

        static void Main(string[] args)
        {
            var cityDB = new OrdersManager(Configuration);

            var newOD = cityDB.AddOrder(new Orders { delivery_time=new DateTime(2018,01,01), customers_id=1 });
         
            
            var test = cityDB.GetOrder(1);

            /*foreach (var essai in test)
            {
                Console.WriteLine(essai.ToString());
            }

            Console.WriteLine(cityDB.GetOrder_dishes(1,1));*/
        }

    }
}

