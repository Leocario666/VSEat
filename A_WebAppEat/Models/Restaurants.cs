﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A_WebAppEat.Models
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
