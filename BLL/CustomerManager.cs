using DAL;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CustomerManager:ICustomerManager
    {
        private ICustomerDB CustomerDb { get; }

        public CustomerManager (ICustomerDB customerDB)
        {
            CustomerDb = customerDB;
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
