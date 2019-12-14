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

namespace VSEat.Controllers
{
    public class DeliveryStaffController : Controller
    {
        private IDelivery_staffManager DSManager { get; }
        private IConfiguration Configuration { get; }
        public int IdLog { get; set; }
        private string pseudo;
        public DeliveryStaffController(IDelivery_staffManager ds)
        {
            DSManager = ds;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        
        //Login page for a deliverer
        public ActionResult Index(DTO.Delivery_staff ds)
        {
            //Check if the user exists
            if (DSManager.isUserValid(ds))
            {
                HttpContext.Session.SetString("login", ds.login);

                var allDeliverer = DSManager.GetDelivery_staffs();

                //setting multiple variables in sessions, so that we can re-use them
                foreach (var deliverer in allDeliverer)
                {
                    if (ds.login == deliverer.login)
                    {
                        IdLog = deliverer.delivery_staff_Id;
                        HttpContext.Session.SetInt32("idDL", IdLog);
                        pseudo = deliverer.login;
                        HttpContext.Session.SetString("nameDL", pseudo);
                    }
                }

                //List of his order(s)
                return RedirectToAction("Details", "DeliveryStaff", new { id = IdLog }); 
            }
            else
            {
                //Login page
                return View();
            }


        }



        //List of the deliverer's order(s)
        [HttpGet]
        public ActionResult Details(int id)
        {
            //creation of multiple variables to check conditions and for the display
            IOrderDB order = new OrderDB(Configuration);
            IOrderManager odm = new OrderManager(order);
            ICustomerDB customer = new CustomerDB(Configuration);
            ICustomerManager cm = new CustomerManager(customer);
            ICityDB citydb = new CityDB(Configuration);
            ICityManager cityman = new CityManager(citydb);
            var customerlist = cm.GetCustomers();
            ViewData["Customers"] = customerlist;
            var citylist = cityman.GetCities();
            ViewData["City"] = citylist;

            ViewBag.nameDL = HttpContext.Session.GetString("nameDL");
            var od = odm.GetOrders_ds(id); //Get all orders according to the deliverer's id

            List<Order> odtrie = new List<Order>();
            //Creation of a list which will only contain the non delivery order(s)
            foreach (Order o in od)
            {
                if (o.status.Equals("non delivery"))
                {
                    odtrie.Add(o);
                }
            }

            return View(odtrie); //Display the non delivery order(s)
        }

        //Action to deliver an order
        public ActionResult Delivered(int id)
        {
            //Set a ViewBag with the logged deliverer's id
            ViewBag.idDL = HttpContext.Session.GetInt32("idDL");
            
            IOrderDB order = new OrderDB(Configuration);
            IOrderManager odm = new OrderManager(order);
            var idDL = HttpContext.Session.GetInt32("idDL");
            var od = odm.GetOrder(id);
            od.status = "delivered";
            odm.UpdateOrder(od); //update the order status in delivered

            return View(idDL); //return the view of the deliverer's order(s)
        }


    }
}