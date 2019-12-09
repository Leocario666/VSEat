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
                return RedirectToAction("Index", "Home", new { user = ds.login });
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