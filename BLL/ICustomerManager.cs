
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
        ICustomerDB CustomersDb { get; }
        List<Customer> GetCustomers();
        Customer GetCustomer(int id);
        Customer AddCustomer(Customer customer);
        int UpdateCustomer(Customer customer);
        int DeleteCustomer(int id);
    }
}
