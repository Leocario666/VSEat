﻿using DAL;
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

        // ******************************************************************** // 
        // Method which manages the test of the connection
        // ******************************************************************** // 
        public bool isUserValid(Customer c)
        {
            return CustomerDb.isUserValid(c);
        }


        // ******************************************************************** // 
        // Method which manages the display of one customer
        // ******************************************************************** // 
        public Customer GetCustomer(int id)
        {
            return CustomerDb.GetCustomer(id);
        }

        public List<Customer> GetCustomers()
        {
            return CustomerDb.GetCustomers();
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
