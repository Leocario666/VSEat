﻿using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class DishesManager
    {
        public IDishesDB DishesDb { get; }

        public DishesManager(IConfiguration configuration)
        {
            DishesDb = new DishesDB(configuration);
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