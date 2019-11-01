using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Dishes
    {
        public int id { get; }
        public String name { get; }
        public float price { get; }
        public String status { get; }
        public DateTime created_at { get; }
        public int restaurant_id { get; }

        public override string ToString()
        {
            return $"{id}|{name}|{price}|{status}|{created_at}|{restaurant_id}";
        }
    }
}
