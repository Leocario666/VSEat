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
            IRestaurantDB restodb = new RestaurantDB(Configuration);
            IDishManager dishManager = new DishManager(dish);
            IOrderManager orderManager = new OrderManager(orderdb);
            IOrder_dishesManager order_DishesManager = new Order_dishesManager(orderddb);
            IDelivery_staffManager dlmanager = new Delivery_staffManager(dldb);
            IRestaurantManager restoManager = new RestaurantManager(restodb);


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
                var listeresto = restoManager.GetRestaurants();
                int cityCodeTemp = 0;
                

                foreach (Delivery_staff ds in dslist)
                {

                    foreach(Dish d in plat)
                    { 
                        if (d.dish_Id == dishlist[0].Dish_Id)
                        {
                            foreach (Restaurant r in listeresto)
                            {
                                if (d.restaurant_Id == r.restaurant_Id)
                                {
                                    cityCodeTemp = r.cityCode;
                                }
                            }
                        }
                    }

                    if (ds.cityCode == cityCodeTemp)
                    {
                        var isbusy = false;
                        var oListByDl = orderManager.GetOrders_ds(ds.delivery_staff_Id);
                        int cptOrder = 0;
                        foreach (Order o in oListByDl)
                        {
                             if(o.status == "non delivery")
                            {
                                string deliveryTimePourInt = o.delivery_time.Remove(1,1);
                                string deliveryTimePartOne = deliveryTimePourInt.Substring(0,1);
                                string deliveryTimePartTwo = deliveryTimePourInt.Substring(2);
                                int test = Int32.Parse(deliveryTimePartTwo);
                                switch (test)
                                {
                                    case 00:
                                        break;

                                    case 15:
                                        test = 25;
                                        break;
                                    case 30:
                                        test = 50;
                                        break;
                                    case 45:
                                        test = 75;
                                        break;
                                }
                                deliveryTimePartTwo = test.ToString();

                                int deliveryTimeInt = Int32.Parse(deliveryTimePartOne + deliveryTimePartTwo);

                                string deliveryTimeForCompare = deliveryTime.Remove(1, 1);

                                string dtPartOne = deliveryTimeForCompare.Substring(0, 1);
                                string dtPartTwo = deliveryTimeForCompare.Substring(2);
                                int essai = Int32.Parse(deliveryTimePartTwo);
                                switch (essai)
                                {
                                    case 00:
                                        break;

                                    case 15:
                                        test = 25;
                                        break;
                                    case 30:
                                        test = 50;
                                        break;
                                    case 45:
                                        test = 75;
                                        break;
                                }
                                dtPartTwo = test.ToString();
                                int dTForCompare = Int32.Parse(dtPartOne + dtPartTwo);
                                int compare = (deliveryTimeInt - dTForCompare);

                                if(compare <= 50 || compare >= -50)
                                {
                                    cptOrder++;
                                }


                            }
                        }

                        if(cptOrder == 5)
                        {
                            isbusy = true;
                        }


                        if (isbusy == false)
                        {
                            idDs = ds.delivery_staff_Id;
                        }
                    }
                }

                if(idDs != -1)
                {
                    ikse.delivery_staff_Id = idDs;

                    var orderaiedi = orderManager.AddOrder(ikse);

                    foreach (Dish_Order disho in dishlist)
                    {
                        Order_dishes order_dishes_ = new Order_dishes();
                        order_dishes_.order_Id = orderaiedi;
                        order_dishes_.dish_Id = disho.Dish_Id;
                        order_dishes_.quantity = disho.Quantity;
                        order_dishes_.price = disho.totalPrice;
                        if (order_dishes_.quantity != 0)
                        {
                            order_DishesManager.AddOrder_dishes(order_dishes_);
                        }
                    }

                    return View();
                }
                
            }

            return RedirectToAction("error", "Restaurant");
        }

        public ActionResult error()
        {
            return View();
        }

    }
}