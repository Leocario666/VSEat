using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class DishManager:IDishManager
    {
        public IDishDB DishDb { get; }

        public DishManager(IDishDB dishDB)
        {
            DishDb = dishDB;
        }

        // ******************************************************************** // 
        // Method which manages the display of all dishes for one restaurant
        // ******************************************************************** // 
        public List<Dish> GetDishes(int idRestaurant)
        {
            return DishDb.GetDishes(idRestaurant);
        }

        // ******************************************************************** // 
        // Method which manages the display of one dish
        // ******************************************************************** // 
        public Dish GetDish(int id)
        {
            return DishDb.GetDish(id);
        }
    }
}
