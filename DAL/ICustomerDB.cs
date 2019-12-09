using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface ICustomerDB
    {
        // List of the methods we can use
        List<String> GetCustomersLogins();
        List<Customer> GetCustomersPasswords();
        Customer GetCustomer(int id);
        Customer AddCustomer(Customer customer);
       


           

    }
}
