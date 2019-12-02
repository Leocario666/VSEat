using DAL;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CustomerManager 
    {
        public ICustomerDB CustomerDb { get; }

        public CustomerManager (IConfiguration configuration)
        {
            CustomerDb = new CustomerDB(configuration);
        }

        public List<Customer> GetCustomers()
        {
            return CustomerDb.GetCustomers();
        }

        public Customer GetCustomer(int id)
        {
            return CustomerDb.GetCustomer(id);
        }

        public Customer AddCustomer(Customer customer)
        {
            return CustomerDb.AddCustomer(customer);
        }

        


    }
}
