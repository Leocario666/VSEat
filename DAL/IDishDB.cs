﻿using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IDishDB
    {
        
        List<Dish> GetDishes(int idRestaurant);
        Dish GetDish(int id);
       
    }
}
