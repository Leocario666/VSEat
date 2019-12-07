using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IOrderManager
    {
        // List of the methods we can use 
        List<Order> GetOrders(int idCustomer);
        Order GetOrder(int id);
        Order AddOrder(Order order);
        int UpdateOrder(Order order);
    }
}
