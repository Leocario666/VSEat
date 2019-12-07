using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IDishManager
    {
        
        List<Dish> GetDishes(int idRestaurant);
        Dish GetDish(int id);

    }
}
