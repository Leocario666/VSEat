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
            var hotelsDB = new CustomersManager(Configuration);

            var hotels = CustomersDB.GetCustomers();

            foreach (var hotel in hotels)
            {
                Console.WriteLine(hotel.ToString());
            }
        }

    }
}

