using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Order_dishes
    {
        public int order_id { get; set; }
        public int dishes_id { get; set; }
        public int quantity { get; set; }
        public int delivery_staff_id { get; set; }
        public float price { get; set; }

        public override string ToString()
        {
            return $"{order_id}|{dishes_id}|{quantity}|{delivery_staff_id}|{price}";
        }
    }
}
