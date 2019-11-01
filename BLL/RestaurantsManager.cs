using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class RestaurantsManager
    {
        public IRestaurantsDB RestaurantsDB { get; }

        public RestaurantsManager(IConfiguration configuration)
        {
            RestaurantsDB = new RestaurantsDB(configuration);
        }

        public List<Restaurants> GetRestaurants()
        {
            return RestaurantsDB.GetRestaurants();
        }

        public Restaurants GetRestaurant(int id)
        {
            return RestaurantsDB.GetRestaurant(id);
        }
    }
}
