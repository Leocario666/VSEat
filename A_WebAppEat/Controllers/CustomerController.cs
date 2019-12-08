using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VSEat.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerManager CustomerManager { get; }
        public CustomerController(ICustomerManager customerManager)
        {
            CustomerManager = customerManager;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

       public ActionResult Index(DTO.Customer c)
        {
            HttpContext.Session.SetString("login", c.login);
            return RedirectToAction("Index", "Restaurant", new { user = "User" });
        }


        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
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
            CustomerManager.AddCustomer(c);
            return RedirectToAction(nameof(Index));
        }

        // POST: Customer/Create
 
        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
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

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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