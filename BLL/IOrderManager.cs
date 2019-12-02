using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IOrderManager
    {
        IOrderDB OrdersDb { get; }
        List<Order> GetOrders(int idCustomer);
        Order GetOrder(int id);
        Order AddOrder(Order order);
        int UpdateOrder(Order order);
    }
}
