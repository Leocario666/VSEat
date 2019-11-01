using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    class Restaurants
    {
        public int id { get; }
        public string name { get; }
        public DateTime created_at { get; }
        public int city_code { get; }

        public override string ToString()
        {
            return $"{id}|{name}|{created_at}|{city_code}";
        }
    }
}
