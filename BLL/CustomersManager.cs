using DAL;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CustomersManager 
    {
        public ICustomersDB CustomerDb { get; }

        public CustomersManager (IConfiguration configuration)
        {
            CustomerDb = new CustomersDB(configuration);
        }

        public List<Customers> GetCustomers()
        {
            return CustomerDb.GetCustomers();
        }

        public Customers GetCustomer(int id)
        {
            return CustomerDb.GetCustomer(id);
        }

        public Customers AddCustomer(Customers customer)
        {
            return CustomerDb.AddCustomer(customer);
        }

        public int DeleteCustomer(int id)
        {
            return CustomerDb.DeleteCustomer(id);
        }
        public int UpdateCustomer(Customers customers)
        {
            return CustomerDb.UpdateCustomer(customers);
        }


    }
}
