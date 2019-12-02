using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IRestaurantManager
    {
        List<Restaurant> GetRestaurants();
        Restaurant GetRestaurant(int id);
    }
}
