using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Dish
    {
        public int dish_Id { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public int restaurant_Id { get; set; }
    }
}
