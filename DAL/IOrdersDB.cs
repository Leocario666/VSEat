using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public interface IOrdersDB
    {
        IConfiguration Configuration { get; }
        List<Orders> GetOrders(int idCustomer);
        Orders GetOrder(int code);
        Orders AddOrder(Orders order);
        int UpdateOrder(Orders order);
        int DeleteOrder(int id);
    }
}
