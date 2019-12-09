
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
            ICustomerDB customerDB = new CustomerDB(Configuration);
            ICustomerManager customerManager = new CustomerManager(customerDB);
            Customer c = new Customer();

            var customersL = customerManager.GetCustomersLogins();

            foreach (var customer in customersL)
            {
                Console.WriteLine(customer.ToString());
            }
        }

    }
}

