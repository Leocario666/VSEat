using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VSEat.Controllers
{
    public class DeliveryStaffController : Controller
    {
        private IDelivery_staffManager DSManager { get; }
        private int id;
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
                        id = deliverer.delivery_staff_Id;
                    }
                }

                return RedirectToAction("Index", "Home", new { user = id });
            } else
            {
                return View();
            }
            
            
        }

        // GET: DeliveryStaff/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

       
    }
}