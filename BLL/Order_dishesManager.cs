using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Microsoft.Extensions.Configuration;
using DTO;

namespace BLL
{
    public class Order_dishesManager:IOrder_dishesManager
    {
        private IOrder_dishesDB Order_dishesDB { get; }

        public Order_dishesManager(IOrder_dishesDB order_DishesDB)
        {
            Order_dishesDB = order_DishesDB;
        }

        // ******************************************************************** // 
        // Method which manages the display of all Order dishes for one order
        // ******************************************************************** // 
        public List<Order_dishes> GetOrders_dishes(int order_id)
        {
            return Order_dishesDB.GetOrders_dishes(order_id);
        }

        // ****************************************************************************** // 
        // Method which manages the display of all Order dishes for one delivery staff 
        // ****************************************************************************** // 
        public List<Order_dishes> GetOrders_dishes_ds(int delivery_staff_id)
        {
            return Order_dishesDB.GetOrders_dishes_ds(delivery_staff_id);
        }

        // ************************************************************* // 
        // Method which manages the display of one Order dishes
        // ************************************************************* // 
        public Order_dishes GetOrder_dishes(int order_id, int dishes_id)
        {
            return Order_dishesDB.GetOrder_dishes(order_id, dishes_id);
        }

        // ************************************************************* // 
        // Method which manages the adding of one order dishes
        // ************************************************************* // 
        public Order_dishes AddOrder_dishes(Order_dishes order_dishes)
        {
            return Order_dishesDB.AddOrder_dishes(order_dishes);
        }

        // ************************************************************* // 
        // Method which manages the update of one Order dishes
        // ************************************************************* // 
        public int UpdateOrder_dishes(Order_dishes order_dishes)
        {
            return Order_dishesDB.UpdateOrder_dishes(order_dishes);
        }
    }
}
