using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Dishes
    {
        public int id { get; set; }
        public String name { get; set; }
        public float price { get; set; }
       
        public int restaurant_id { get; set; }

        public override string ToString()
        {
            return $"{id}|{name}|{price}|{restaurant_id}";
        }
    }
}
