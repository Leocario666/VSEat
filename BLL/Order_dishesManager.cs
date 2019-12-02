using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Microsoft.Extensions.Configuration;
using DTO;

namespace BLL
{
    public class Order_dishesManager
    {
        public IOrder_dishesDB Order_dishesDB { get; }

        public Order_dishesManager(IConfiguration configuration)
        {
            Order_dishesDB = new Order_dishesDB(configuration);
        }

        public List<Order_dishes> GetOrders_dishes(int order_id)
        {
            return Order_dishesDB.GetOrders_dishes(order_id);
        }

        public List<Order_dishes> GetOrders_dishes_ds(int delivery_staff_id)
        {
            return Order_dishesDB.GetOrders_dishes_ds(delivery_staff_id);
        }

        public Order_dishes GetOrder_dishes(int order_id, int dishes_id)
        {
            return Order_dishesDB.GetOrder_dishes(order_id, dishes_id);
        }

        public Order_dishes AddOrder_dishes(Order_dishes order_dishes)
        {
            return Order_dishesDB.AddOrder_dishes(order_dishes);
        }

        public int UpdateOrder_dishes(Order_dishes order_dishes)
        {
            return Order_dishesDB.UpdateOrder_dishes(order_dishes);
        }
    }
}
