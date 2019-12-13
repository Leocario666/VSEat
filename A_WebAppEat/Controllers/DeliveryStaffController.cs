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
        // GET: DeliveryStaff
        public ActionResult Index(DTO.Delivery_staff ds) 
        {
            if (DSManager.isUserValid(ds))
            {
                HttpContext.Session.SetString("login", ds.login);

                var allDeliverer = DSManager.GetDelivery_staffs();

                foreach (var deliverer in allDeliverer)
                {
                    if (ds.login == deliverer.login)
                    {
                        IdLog = deliverer.delivery_staff_Id;
                        HttpContext.Session.SetInt32("idDL", IdLog);
                        HttpContext.Session.SetString("nameDL", deliverer.login);
                        pseudo = deliverer.login;
                        
                    }
                }

                return RedirectToAction("Details", "DeliveryStaff", new { id = IdLog } );
            } else
            {
                return View();
            }
            
            
        }

        

        // GET: DeliveryStaff/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
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
            var od = odm.GetOrders_ds(id);

            List<Order> odtrie = new List<Order>();

            foreach(Order o in od)
            {
                if(o.status.Equals("non delivery"))
                {
                    odtrie.Add(o);
                }
            }

            return View(odtrie);
        }

        public ActionResult Delivered(int id)
        {
            ViewBag.idDL = HttpContext.Session.GetInt32("idDL");
            ViewBag.idTest = id;
            IOrderDB order = new OrderDB(Configuration);
            IOrderManager odm = new OrderManager(order);
            var idDL = HttpContext.Session.GetInt32("idDL");
            var od = odm.GetOrder(id);
            od.status = "delivered";
            odm.UpdateOrder(od);

            return View(idDL);
        }

       
    }
}