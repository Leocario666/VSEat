using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public interface IOrderDB
    {
        
        List<Order> GetOrders(int idCustomer);
        Order GetOrder(int id);
        Order AddOrder(Order order);
        int UpdateOrder(Order order);
    }
}
