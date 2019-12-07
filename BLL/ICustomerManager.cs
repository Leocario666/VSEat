
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
        Customer GetCustomer(int id);
        Customer AddCustomer(Customer customer);
       
    }
}
