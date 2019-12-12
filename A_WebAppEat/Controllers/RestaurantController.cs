﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VSEat.Models;

namespace A_WebAppEat.Controllers
{
    public class RestaurantController : Controller
    {
        private IOrderManager orderManager { get; }
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
            HttpContext.Session.SetInt32("idResto", id);

            return View(dishes);

        }

        [HttpGet]
        //GET : Restaurtant/command
        public ActionResult Command(string carbonra, string steak, DateTime deliveryTime)
        {
            IDishDB dish = new DishDB(Configuration);
            IDishManager dishManager = new DishManager(dish);

            List<Dish_Order> dishlist = null;
            List<Dish> plat = dishManager.GetDishes((int)HttpContext.Session.GetInt32("idResto"));
            List <string> s = new List<string>();
            s.Add(carbonra);
            s.Add(steak);

            int x = 0;
            int quantitytemp;
            float pricetemp;
            float priceGeneral = 0;
            Dish_Order order = new Dish_Order();
            foreach(Dish d in plat)
            {
                order.Dish_Id = d.dish_Id;
                order.Name = d.name;
                order.Price = d.price;
                pricetemp = d.price;
                order.Quantity = Int32.Parse(s.ElementAt(x));
                quantitytemp = Int32.Parse(s.ElementAt(x));
                order.totalPrice = quantitytemp * pricetemp;
                priceGeneral += quantitytemp * pricetemp;
                pricetemp = d.price;
                x++;
            }

                


            return View(priceGeneral);
        }

    }
}