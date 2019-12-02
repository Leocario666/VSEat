using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Order
    {
        public int order_Id { get; set; }
        public String status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime delivery_time { get; set; }
        public int customer_Id { get; set; }
    }
}
