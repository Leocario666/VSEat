using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class RestaurantManager:IRestaurantManager
    {
        private IRestaurantDB RestaurantDB { get; }

        public RestaurantManager(IRestaurantDB restaurantDB)
        {
            RestaurantDB = restaurantDB;
        }

        // ************************************************************* // 
        // Method which manages the display of all restaurants
        // ************************************************************* // 
        public List<Restaurant> GetRestaurants()
        {
            return RestaurantDB.GetRestaurants();
        }

        // ************************************************************* // 
        // Method which manages the display of one restaurants
        // ************************************************************* // 
        public Restaurant GetRestaurant(int id)
        {
            return RestaurantDB.GetRestaurant(id);
        }
    }
}
