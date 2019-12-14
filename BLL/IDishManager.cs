using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IDishManager
    {
        // List of the methods we can use 
        List<Dish> GetDishes(int idRestaurant);
        List<Dish> GetAllDishes();
        Dish GetDish(int id);

    }
}
