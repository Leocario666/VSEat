using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using DTO;
using BLL;

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
            var test = new DishesManager(Configuration);

            var dishes = test.GetDishes(1);

            foreach(var cc in dishes)
            {
                Console.WriteLine(cc.ToString());
            }
        }

    }
}

