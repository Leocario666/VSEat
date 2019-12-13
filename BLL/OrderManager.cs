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

        // ******************************************************************* // 
        // Method which manages the display of all the order of a customer
        // ******************************************************************* // 
        public List<Order> GetOrders(int idCustomer)
        {
            return OrderDb.GetOrders(idCustomer);
        }

        // ************************************************************* // 
        // Method which manages the display of one order
        // ************************************************************* // 
        public Order GetOrder(int id)
        {
            return OrderDb.GetOrder(id);
        }

        // ****************************************************************************** // 
        // Method which manages the display of all Orders for one delivery staff 
        // ****************************************************************************** // 
        public List<Order> GetOrders_ds(int delivery_staff_id)
        {
            return OrderDb.GetOrders_ds(delivery_staff_id);
        }

        // ************************************************************* // 
        // Method which manages the display of all orders
        // ************************************************************* // 
        public List<Order> GetOrders()
        {
            return OrderDb.GetOrders();
        }

        // ************************************************************* // 
        // Method which manages the adding of one order
        // ************************************************************* // 
        public int AddOrder(Order order)
        {
            return OrderDb.AddOrder(order);
        }

        // ************************************************************* // 
        // Method which manages the display of all restaurants
        // ************************************************************* // 
        public int UpdateOrder(Order order)
        {
            return OrderDb.UpdateOrder(order);
        }
    }
}
