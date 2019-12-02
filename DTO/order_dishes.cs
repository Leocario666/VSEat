using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Order_dishes
    {
        public int order_Id { get; set; }
        public int dish_Id { get; set; }
        public int quantity { get; set; }
        public int delivery_staff_Id { get; set; }
        public float price { get; set; }
    }
}
