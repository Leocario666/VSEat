using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Restaurants
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime created_at { get; set; }
        public int city_code { get; set; }

        public override string ToString()
        {
            return $"{id}|{name}|{created_at}|{city_code}";
        }
    }
}
