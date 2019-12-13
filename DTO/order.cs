using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DTO
{
    // Object Order
    public class Order
    {
       
        public int order_Id { get; set; }
        public string status { get; set; }
        public float totalPrice { get; set; }
        public DateTime created_at { get; set; }
        public string delivery_time { get; set; }
        public int customer_Id { get; set; }
        public int delivery_staff_Id { get; set; }
    }
}
