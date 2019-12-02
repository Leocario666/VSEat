using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class RestaurantManager
    {
        public IRestaurantDB RestaurantDB { get; }

        public RestaurantManager(IConfiguration configuration)
        {
            RestaurantDB = new RestaurantDB(configuration);
        }

        public List<Restaurant> GetRestaurants()
        {
            return RestaurantDB.GetRestaurants();
        }

        public Restaurant GetRestaurant(int id)
        {
            return RestaurantDB.GetRestaurant(id);
        }
    }
}
