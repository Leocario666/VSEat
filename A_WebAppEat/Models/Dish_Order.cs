using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSEat.Models
{
    public class Dish_Order
    {
        //Model for the command action
        public int Dish_Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public float totalPrice { get; set; }

        public Dish_Order()
        {
        }
    }
}
