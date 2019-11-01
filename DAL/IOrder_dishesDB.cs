using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IOrder_dishesDB
    {
        IConfiguration Configuration { get; }
        List<Order_dishes> GetOrders_dishes(int order_id);
        Order_dishes GetOrder_dishes(int order_id, int dishes_id);
        Order_dishes AddOrder_dishes(Order_dishes Order_dishes);
        int UpdateOrder_dishes(Order_dishes Order_dishes);
        int DeleteOrder_dishes(int order_id, int dishes_id);
    }
}
