using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IOrdersManager
    {
        IOrdersDB OrdersDb { get; }
        List<Orders> GetOrders(int idCustomer);
        Orders GetOrder(int code);
        Orders AddOrder(Orders order);
        int UpdateOrder(Orders order);
        int DeleteOrder(int id);
    }
}
