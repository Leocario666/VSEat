using DAL;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class OrdersManager
    {
        public IOrdersDB OrdersDb { get; }

        public OrdersManager(IConfiguration configuration)
        {
            OrdersDb = new OrdersDB(configuration);
        }

        public List<Orders> GetOrders(int idCustomer)
        {
            return OrdersDb.GetOrders(idCustomer);
        }

        public Orders GetOrder(int id)
        {
            return OrdersDb.GetOrder(id);
        }

        public Orders AddOrder(Orders order)
        {
            return OrdersDb.AddOrder(order);
        }

        public int UpdateOrder(Orders order)
        {
            return OrdersDb.UpdateOrder(order);
        }

        public int DeleteOrder(int id)
        {
            return OrdersDb.DeleteOrder(id);
        }
    }
}
