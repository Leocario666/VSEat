﻿using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IDishesManager
    {
        IDishesDB DishesDb { get; }
        List<Dishes> GetDishes(int idRestaurant);
        Dishes GetDish(int id);

    }
}