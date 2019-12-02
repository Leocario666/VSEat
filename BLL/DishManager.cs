using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class DishManager
    {
        public IDishDB DishDb { get; }

        public DishManager(IConfiguration configuration)
        {
            DishDb = new DishDB(configuration);
        }

        public List<Dish> GetDishes(int idRestaurant)
        {
            return DishDb.GetDishes(idRestaurant);
        }

        public Dish GetDish(int id)
        {
            return DishDb.GetDish(id);
        }
    }
}
