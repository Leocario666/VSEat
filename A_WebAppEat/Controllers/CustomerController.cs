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
        private string pseudo;
       
        
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

       public ActionResult Index(Customer c)
        {
            if (CustomerManager.isUserValid(c))
            {
                HttpContext.Session.SetString("login", c.login);
                var allCustomer = CustomerManager.GetCustomers();
                
                foreach(var customer in allCustomer)
                {
                    if(c.login == customer.login)
                    {
                        id = customer.customer_Id;
                        this.id = id;
                        pseudo = customer.login;
                    }
                }
                
                return RedirectToAction("Index", "Home", new { user = id.ToString()});
            }
            else
            {
                return View();
            }
        }


       

        
        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            IOrderDB order = new OrderDB(Configuration);
            IOrderManager om = new OrderManager(order);

            var test = om.GetOrders(id);

            return View(test);
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

            var citieslist = cityManager.GetCities();

           
            ViewBag.City = citieslist;
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