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
        List<Order> GetOrders_ds(int delivery_staff_Id);
        Order GetOrder(int id);
        int AddOrder(Order order);
        int UpdateOrder(Order order);
    }
}
