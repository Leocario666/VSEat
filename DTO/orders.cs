using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    class Orders
    {
        public int id { get; set; }
        public String status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime delivery_time { get; set; }
        public int customers_id { get; set; }

        public override string ToString()
        {
            return $"{id}|{status}|{created_at}|{delivery_time}|{customers_id}";
        }
    }
}
