using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public interface IOrderDB
    {
        // List of the methods we can use
        List<Order> GetOrders(int idCustomer);
        List<Order> GetOrders_ds(int delivery_staff_Id);
        Order GetOrder(int id);
        Order AddOrder(Order order);
        int UpdateOrder(Order order);
    }
}
