using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace A_WebAppEat.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantManager RestaurantManager { get; }
        private IDishManager dishManager { get; }



        public RestaurantController(IRestaurantManager restaurantManager)
        {
            
            RestaurantManager = restaurantManager;
            
        }

       

        // GET: Restaurant
        public ActionResult Index()
        {
            var restaurant = RestaurantManager.GetRestaurants();
            return View(restaurant);
        }



        // GET: Restaurant/Details/5
        public ActionResult Details(int id)
        {

            var restaurant = RestaurantManager.GetRestaurant(id);

            return View(restaurant);
        }

        public ActionResult Plat(int micha)
        {
            var dish = dishManager.GetDishes(micha);

            return View(dish);
        }
    
        
    }
}