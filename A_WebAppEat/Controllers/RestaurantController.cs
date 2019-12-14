using System;
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
        private IOrder_dishesManager order_dishesManager { get; }
        private IRestaurantManager RestaurantManager { get; }
        private IConfiguration Configuration { get; }

        public RestaurantController(IRestaurantManager restaurantManager)
        {
            
            RestaurantManager = restaurantManager;
            
        }

        // GET: Restaurant
        public ActionResult Index()
        {
            ICityDB cityDB = new CityDB(Configuration);
            ICityManager cityManager = new CityManager(cityDB);
            var restaurant = RestaurantManager.GetRestaurants();
            ViewData["Cities"] = cityManager.GetCities();
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

        [HttpPost]
        //POST : Restaurtant/command
        public ActionResult Command()
        {
            string platun = Request.Form["platun"];
            string platunun = Request.Form["platunun"];
            string platununun = Request.Form["platununun"];
            string platunununun = Request.Form["platunununun"];
            string deliveryTime = Request.Form["deliveryTime"];
            IDishDB dish = new DishDB(Configuration);
            IOrderDB orderdb = new OrderDB(Configuration);
            IOrder_dishesDB orderddb = new Order_dishesDB(Configuration);
            IDelivery_staffDB dldb = new Delivery_staffDB(Configuration);
            IDishManager dishManager = new DishManager(dish);
            IOrderManager orderManager = new OrderManager(orderdb);
            IOrder_dishesManager order_DishesManager = new Order_dishesManager(orderddb);
            IDelivery_staffManager dlmanager = new Delivery_staffManager(dldb);


            List<Dish_Order> dishlist = new List<Dish_Order>();
            List<Dish> plat = dishManager.GetDishes((int)HttpContext.Session.GetInt32("idResto"));
            List <string> s = new List<string>();
            s.Add(platun);
            s.Add(platunun);
            if(platununun != null)
            {
                s.Add(platununun);
            }
            if(platunununun != null)
            {
                s.Add(platunununun);
            }

            int x = 0;
            int quantitytemp;
            float pricetemp;
            float priceGeneral = 0;
            
            foreach(Dish d in plat)
            {
                Dish_Order order = new Dish_Order();
                order.Dish_Id = d.dish_Id;
                order.Name = d.name;
                order.Price = d.price;
                pricetemp = d.price;
                order.Quantity = Int32.Parse(s.ElementAt(x));
                quantitytemp = Int32.Parse(s.ElementAt(x));
                order.totalPrice = quantitytemp * pricetemp;
                priceGeneral += quantitytemp * pricetemp;
                dishlist.Add(order);
                x++;
            }

            ViewBag.prix = priceGeneral;

            if(priceGeneral != 0)
            {
                Order ikse = new Order();
                ikse.delivery_time = deliveryTime;
                ikse.totalPrice = priceGeneral;
                ikse.customer_Id = (int)HttpContext.Session.GetInt32("id");
                //ikse.delivery_staff_Id = 1;

                var dslist = dlmanager.GetDelivery_staffs();
                int idDs = -1;

                foreach(Delivery_staff ds in dslist)
                {
                    if(ds.cityCode == 1974)
                    {
                        var isbusy = false;
                        if (isbusy == false)
                        {
                            idDs = ds.delivery_staff_Id;
                        }
                    }
                }

                ikse.delivery_staff_Id = idDs;

                var orderaiedi = orderManager.AddOrder(ikse);

                foreach (Dish_Order disho in dishlist)
                {
                    Order_dishes order_dishes_ = new Order_dishes();
                    order_dishes_.order_Id = orderaiedi;
                    order_dishes_.dish_Id = disho.Dish_Id;
                    order_dishes_.quantity = disho.Quantity;
                    order_dishes_.price = disho.totalPrice;
                    if(order_dishes_.quantity != 0)
                    {
                        order_DishesManager.AddOrder_dishes(order_dishes_);
                    }
                }
            }

            return View();
        }

    }
}