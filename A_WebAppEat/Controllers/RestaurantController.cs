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

        //List of all restaurants
        public ActionResult Index()
        {
            ICityDB cityDB = new CityDB(Configuration);
            ICityManager cityManager = new CityManager(cityDB);

            //creation of a ViewData for the display
            var restaurant = RestaurantManager.GetRestaurants();
            ViewData["Cities"] = cityManager.GetCities();
            return View(restaurant); //return the list of all restaurants
        }


        //Display the list of dishes of a restaurant
        public ActionResult Plat(int id)
        {
            IDishDB dish = new DishDB(Configuration);
            IDishManager dishManager = new DishManager(dish);



            var dishes = dishManager.GetDishes(id);
            HttpContext.Session.SetInt32("idResto", id); //setting a session for the command action

            ViewBag.id = id;

            return View(dishes);
        }

        [HttpPost]
        //POST : Restaurtant/command
        public ActionResult Command()
        {
            //take back the Form
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

            //creation of lists for create the orders and the order_dishes
            List<Dish_Order> dishlist = new List<Dish_Order>();
            //List of dish
            List<Dish> plat = dishManager.GetDishes((int)HttpContext.Session.GetInt32("idResto"));
            //List of quantity
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
            
            //Creation of my ViewModel Dish_Order 
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

            //Set the Final price for the view
            ViewBag.prix = priceGeneral;

            //if the customer has select at least 1 dish
            if(priceGeneral != 0)
            {
                //Create a new Order
                Order ikse = new Order();
                ikse.delivery_time = deliveryTime;
                ikse.totalPrice = priceGeneral;
                ikse.customer_Id = (int)HttpContext.Session.GetInt32("id");

                //select whitch delivery staff is available
                var dslist = dlmanager.GetDelivery_staffs();
                int idDs = -1;
                var listeresto = restoManager.GetRestaurants();
                int cityCodeTemp = 0;
                
                //Select the list of delivery staff
                foreach (Delivery_staff ds in dslist)
                {
                    //find the city of the restaurant
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

                    //if the delivery staff is at the good city
                    if (ds.cityCode == cityCodeTemp)
                    {
                        var isbusy = false;
                        var oListByDl = orderManager.GetOrders_ds(ds.delivery_staff_Id);
                        int cptOrder = 0;
                        foreach (Order o in oListByDl)
                        {
                            //select the orders non delivery
                             if(o.status == "non delivery")
                            {
                                //change the 11:00 in 1100, change the minutes from base 60 to base 100 for calculation
                                string deliveryTimePourInt = o.delivery_time.Remove(2,1);
                                string deliveryTimePartOne = deliveryTimePourInt.Substring(0,2);
                                string deliveryTimePartTwo = deliveryTimePourInt.Substring(2);
                                int test = Int32.Parse(deliveryTimePartTwo);
                                switch (test)
                                {
                                    case 0:
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
                                //correct the houres
                                if (deliveryTimeInt % 10 == 0)
                                {
                                    deliveryTimeInt *= 10;
                                    if (deliveryTimeInt / 10000 != 0)
                                    {
                                        deliveryTimeInt /= 10;
                                    }
                                }
                                //same think for the delivery time of the order
                                string deliveryTimeForCompare = deliveryTime.Remove(2, 1);

                                string dtPartOne = deliveryTimeForCompare.Substring(0, 2);
                                string dtPartTwo = deliveryTimeForCompare.Substring(2);
                                int essai = Int32.Parse(dtPartTwo);
                                switch (essai)
                                {
                                    case 0:
                                        break;

                                    case 15:
                                        essai = 25;
                                        break;
                                    case 30:
                                        essai = 50;
                                        break;
                                    case 45:
                                        essai = 75;
                                        break;
                                }
                                dtPartTwo = essai.ToString();
                                int dTForCompare = Int32.Parse(dtPartOne + dtPartTwo);
                                if (dTForCompare %10 == 0)
                                {
                                    dTForCompare *= 10;
                                    if(dTForCompare / 10000 != 0)
                                    {
                                        dTForCompare /= 10;
                                    }
                                }
                                int compare = (deliveryTimeInt - dTForCompare);

                                //if the order is within 15 minutes before or after the delivery staff's order 
                                if (compare <= 25 && compare>= -25)
                                {
                                    cptOrder++;
                                }
                             }
                        }
                        //if the staff is busy
                        if(cptOrder >= 5)
                        {
                            isbusy = true;
                        }
                        //if the staff is free
                        if (isbusy == false)
                        {
                            //assign the staff to the order
                            idDs = ds.delivery_staff_Id;
                        }
                    }
                }
                //if a staff is free
                if(idDs != -1)
                {
                    //assign the staff 
                    ikse.delivery_staff_Id = idDs;

                    //create the order in the database
                    var orderaiedi = orderManager.AddOrder(ikse);

                    //create the order dishes and add to the database
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
                    //return the normal view
                    return View();
                }
                //if no staff is free
                else
                {
                    //return the error view
                    return RedirectToAction("ErrorNoDs", "Restaurant");
                }
                
            }
            //if the customer didn't select any dish, return the error view
            return RedirectToAction("ErrorNoQuantity", "Restaurant");
        }

        //Error page if no deliverer is available
        public ActionResult ErrorNoDs()
        {
            return View();
        }

        //Error page if no quantity is set
        public ActionResult ErrorNoQuantity()
        {
            return View();
        }

    }
}