
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
       
        Customer GetCustomer(int id);
        Customer AddCustomer(Customer customer);
       
    }
}
