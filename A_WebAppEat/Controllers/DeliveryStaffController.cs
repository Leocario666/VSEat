using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL;
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
            IOrder_dishesDB order_Dishes = new Order_dishesDB(Configuration);
            IOrder_dishesManager odm = new Order_dishesManager(order_Dishes);


            
            var od = odm.GetOrders_dishes_ds(id);
            return View(od);
        }

       
    }
}