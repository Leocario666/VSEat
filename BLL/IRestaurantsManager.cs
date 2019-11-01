using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IRestaurantsManager
    {
        IRestaurantsDB RestaurantsDB { get; }

        List<Restaurants> GetRestaurants();
        Restaurants GetRestaurant(int id);
    }
}
