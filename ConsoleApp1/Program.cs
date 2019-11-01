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
            var cityDB = new Order_dishesManager(Configuration);

            var newOD = cityDB.AddOrder_dishes(new Order_dishes { order_id = 1, dishes_id = 1, quantity = 1, price = 27, delivery_staff_id = 1 });

            var cc = new OrdersManager(Configuration);
            
            var dd = cc.AddOrder(new Orders { delivery_time = new DateTime(2018, 02, 09) });
            
            var test = cityDB.GetOrders_dishes(1);

            foreach (var essai in test)
            {
                Console.WriteLine(essai.ToString());
            }

            Console.WriteLine(cityDB.GetOrder_dishes(1,1));
        }

    }
}

