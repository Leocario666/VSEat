
using System;
using System.IO;
using DTO;
using BLL;
using DAL;
using Microsoft.Extensions.Configuration;

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
            var customersDB = new CustomersManager(Configuration);

            var customersL = customersDB.GetCustomers();

            foreach (var customer in customersL)
            {
                Console.WriteLine(customer.ToString());
            }
        }

    }
}

