using DAL;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class OrderManager:IOrderManager
    {
        private IOrderDB OrderDb { get; }

        public OrderManager(IOrderDB orderDB)
        {
            OrderDb = orderDB;
        }

        public List<Order> GetOrders(int idCustomer)
        {
            return OrderDb.GetOrders(idCustomer);
        }

        public Order GetOrder(int id)
        {
            return OrderDb.GetOrder(id);
        }

        public Order AddOrder(Order order)
        {
            return OrderDb.AddOrder(order);
        }

        public int UpdateOrder(Order order)
        {
            return OrderDb.UpdateOrder(order);
        }
    }
}
