using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface ICustomersDB
    {
        IConfiguration Configuration { get; }
        List<Customers> GetCustomers();
        Customers GetCustomer(int id);
        Customers AddCustomer(Customers customer);
        int UpdateCustomer(Customers customer);
        int DeleteCustomer(Customers customer);


           

    }
}
