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

        public bool isUserValid(Customer c)
        {
            return CustomerDb.isUserValid(c);
        }
        public CustomerManager (ICustomerDB customerDB)
        {
            CustomerDb = customerDB;
        }

        public List<String> GetCustomersLogins()
        {
            return CustomerDb.GetCustomersLogins();
        }

        public List<Customer> GetCustomersPasswords()
        {
            return CustomerDb.GetCustomersPasswords();
        }

        // ******************************************************************** // 
        // Method which manages the display of one customer
        // ******************************************************************** // 
        public Customer GetCustomer(int id)
        {
            return CustomerDb.GetCustomer(id);
        }

        // ******************************************************************** // 
        // Method which manages the adding of one customer
        // ******************************************************************** // 
        public Customer AddCustomer(Customer customer)
        {
            return CustomerDb.AddCustomer(customer);
        }


    }
}
