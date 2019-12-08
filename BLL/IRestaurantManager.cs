using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IRestaurantManager
    {
        // List of the methods we can use 
        
        List<Restaurant> GetRestaurants(int cityCode);
        Restaurant GetRestaurant(int id);
    }
}
