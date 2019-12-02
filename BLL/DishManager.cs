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
        public IDishDB DishesDb { get; }

        public DishManager(IConfiguration configuration)
        {
            DishesDb = new DishDB(configuration);
        }

        public List<Dishes> GetDishes(int idRestaurant)
        {
            return DishesDb.GetDishes(idRestaurant);
        }

        public Dishes GetDish(int id)
        {
            return DishesDb.GetDish(id);
        }
    }
}
