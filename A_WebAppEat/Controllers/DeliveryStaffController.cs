using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VSEat.Controllers
{
    public class DeliveryStaffController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        // GET: DeliveryStaff
        public ActionResult Index(DTO.Delivery_staff ds)
        {
            HttpContext.Session.SetString("login", ds.login);
            return RedirectToAction("Index", "Home", new { user = ds.login });
            
        }

        // GET: DeliveryStaff/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DeliveryStaff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeliveryStaff/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DeliveryStaff/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DeliveryStaff/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DeliveryStaff/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DeliveryStaff/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}