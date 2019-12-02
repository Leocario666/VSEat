
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
        ICustomersDB CustomersDb { get; }
        List<Customers> GetCustomers();
        Customers GetCustomer(int id);
        Customers AddCustomer(Customers customer);
        int UpdateCustomer(Customers customer);
        int DeleteCustomer(int id);
    }
}
