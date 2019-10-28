using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    class order_dishes
    {
        public int order_id { get; }
        public int dishes_id { get; }
        public int quantity { get; }
        public int delivery_staff_id { get; }
        public float price { get; }
    }
}
