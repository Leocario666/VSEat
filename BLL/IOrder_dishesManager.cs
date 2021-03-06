﻿using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IOrder_dishesManager
    {
        // List of the methods we can use 
        List<Order_dishes> GetOrders_dishes(int order_id);
        
        Order_dishes GetOrder_dishes(int order_id, int dishes_id);
        Order_dishes AddOrder_dishes(Order_dishes order_dishes);
        List<Order_dishes> GetAllOrders_dishes();
        int UpdateOrder_dishes(Order_dishes order_dishes);
    }
}
