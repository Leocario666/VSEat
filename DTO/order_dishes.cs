using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    // Object Order_dishes
    public class Order_dishes
    {
        public int order_Id { get; set; }
        public int dish_Id { get; set; }
        public int quantity { get; set; }
        
        public float price { get; set; }
    }
}
