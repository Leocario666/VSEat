using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IDishManager
    {
        IDishDB DishDb { get; }
        List<Dish> GetDishes(int idRestaurant);
        Dish GetDish(int id);

    }
}
