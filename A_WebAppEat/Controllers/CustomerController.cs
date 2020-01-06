using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace VSEat.Controllers
{
    public class CustomerController : Controller
    {
        private IConfiguration Configuration { get; }
        private ICustomerManager CustomerManager { get; set; }
        public int id { get; set; }
        public string login { get; set; }


        public CustomerController(ICustomerManager customerManager)
        {
            CustomerManager = customerManager;
            int id = this.id;
        }



        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        //Transition for logging out
        public ActionResult CustomerTransition()
        {
            HttpContext.Session.SetInt32("id", 0);
            HttpContext.Session.SetString("login", "Aucun customer n'est log");
            HttpContext.Session.SetString("nameDL", "Aucun DL n'est log");
            return RedirectToAction("Index", "Customer");
        }
        //Login page for a customer
        public ActionResult Index(Customer c)
        {

            //test if login and password are correct
            if (CustomerManager.isUserValid(c))
            {
                var allCustomer = CustomerManager.GetCustomers();

                //setting multiple variables in sessions, so that we can re-use them
                foreach (var customer in allCustomer)
                {
                    if (c.login == customer.login)
                    {
                        id = customer.customer_Id;
                        login = customer.login;
                        this.id = id;
                        this.login = login;
                        HttpContext.Session.SetInt32("id", id);
                        HttpContext.Session.SetString("login", login);
                        HttpContext.Session.SetString("prenom", customer.first_name);
                        HttpContext.Session.SetString("nom", customer.last_name);
                    }
                }

                //Main page
                return RedirectToAction("Index", "Home", new { user = id.ToString() });
            }
            else
            {
                //Login page
                return View();
            }
        }

        public ActionResult Transition()
        {
            HttpContext.Session.SetString("login", "Aucun customer n'est log");
            HttpContext.Session.SetString("nameDL", "Aucun DL n'est log");
            return RedirectToAction("Index", "Customer");
        }



        // GET: Customer/Details/5
        public ActionResult Details()
        {
            
            if ((string)HttpContext.Session.GetString("login") != "Aucun customer n'est log" && (string)HttpContext.Session.GetString("login") != null) // A customer is logged ?
            {
                //Get the login of the current customer
                ViewBag.login = HttpContext.Session.GetString("login");

                //creation of multiple variables to check conditions and for the display
                IOrderDB order = new OrderDB(Configuration);
                IOrderManager om = new OrderManager(order);
                IDelivery_staffDB dsDB = new Delivery_staffDB(Configuration);
                IDelivery_staffManager dsM = new Delivery_staffManager(dsDB);
                IDishDB dish = new DishDB(Configuration);
                IDishManager dishManager = new DishManager(dish);
                IOrder_dishesDB order_Dishes = new Order_dishesDB(Configuration);
                IOrder_dishesManager odm = new Order_dishesManager(order_Dishes);
                IRestaurantDB restaurant = new RestaurantDB(Configuration);
                IRestaurantManager restaurantManager = new RestaurantManager(restaurant);

                //Get the id of the current customer
                var id = (int)HttpContext.Session.GetInt32("id");

                //Get an orderlist according to the customer id
                var ordersList = om.GetOrders(id); 

                //Creations of multiple ViewData for the display
                var allOrders = om.GetOrders();
                ViewData["AllOrders"] = allOrders;
                var allStaff = dsM.GetDelivery_staffs();
                ViewData["AllStaffs"] = allStaff;
                var allDishes = dishManager.GetAllDishes();
                ViewData["AllDishes"] = allDishes;
                var allOrderDishes = odm.GetAllOrders_dishes();
                ViewData["AllOrderDishes"] = allOrderDishes;
                var allRestaurants = restaurantManager.GetRestaurants();
                ViewData["AllRestaurants"] = allRestaurants;

                //Check if the customer has not order
                if (ordersList == null)
                {
                    return RedirectToAction("DetailsNoOrder", "Customer", new { user = id.ToString() });

                }
                else
                {
                    return View(ordersList); // Return the Details view
                }
            }
            else
            {
                return RedirectToAction("Index", "Customer"); // return to the login page
            }

        }

        //Page to inform the customer that he has not order
        public ActionResult DetailsNoOrder()
        {
            ViewBag.login = HttpContext.Session.GetString("login");
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        // GET: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DTO.Customer c)
        {
            ICityDB cityDB = new CityDB(Configuration);
            ICityManager cityManager = new CityManager(cityDB);

            //Creation of a list of cites so that the user can choose a city from a list during his account creation
            var citieslist = cityManager.GetCities();


            ViewBag.City = citieslist;
            CustomerManager.AddCustomer(c);
            return RedirectToAction(nameof(Index)); //Return to the connection page
        }

        //Display the dish(es) in a specific order
        public ActionResult DishesInOrder(int id)
        {
            IDishDB dish = new DishDB(Configuration);
            IDishManager dishManager = new DishManager(dish);

            IOrder_dishesDB order_Dishes = new Order_dishesDB(Configuration);
            IOrder_dishesManager odm = new Order_dishesManager(order_Dishes);

            //Creation of a ViewData for the display
            var allDishes = dishManager.GetAllDishes();
            ViewData["AllDishes"] = allDishes;


            var orderDishes = odm.GetOrders_dishes(id);
            return View(orderDishes); //Display the list of dish(es)
        }

       

        //Ask the customer: the order number, his forname and lastname
        public ActionResult CancelOrder(int id)
        {
            ViewBag.idOrder = id;
            string idString = id.ToString();
            HttpContext.Session.SetString("idOrderCancel", idString);
            return View(); //Will redirect to TransitionCancel()
        }

        //Check the input and cancel the order
        public ActionResult TransitionCancel ()
        {
            string retour = Request.Form["retour"]; //get the input

            string forTest = HttpContext.Session.GetString("idOrderCancel") + HttpContext.Session.GetString("prenom") + HttpContext.Session.GetString("nom");//set the response

            //compare the input and the response, then update the order if they are equals
            if (retour.Equals(forTest))
            {
                IOrderDB order = new OrderDB(Configuration);
                IOrderManager odm = new OrderManager(order);
                var od = odm.GetOrder(Int32.Parse(HttpContext.Session.GetString("idOrderCancel")));
                od.status = "canceled";
                odm.UpdateOrder(od);
            }

            var id1 = (int)HttpContext.Session.GetInt32("id");
            return RedirectToAction("Details", "Customer", new { user = id1.ToString() }); //Redirect to the orders list

        }
        
    }
}