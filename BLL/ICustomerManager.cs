
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface ICustomerManager
    {
        // List of the methods we can use 
        bool isUserValid(Customer c);
       
        Customer GetCustomer(int id);
        List<Customer> GetCustomers();
        Customer AddCustomer(Customer customer);
       
    }
}
