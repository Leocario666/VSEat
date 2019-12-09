using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace A_WebAppEat.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantManager RestaurantManager { get; }
        private IConfiguration Configuration { get; }

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


        //GET : Restaurant/Plat/1
        public ActionResult Plat(int id)
        {
            IDishDB dish = new DishDB(Configuration);
            IDishManager dishManager = new DishManager(dish);

           
            var dishes = dishManager.GetDishes(id);

            return View(dishes);

        }

        //GET : Restaurtant/command
        public ActionResult Command()
        {
            return View();
        }


    
        
    }
}