using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using A_WebAppEat.Models;
using Microsoft.AspNetCore.Http;

namespace A_WebAppEat.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if ((string)HttpContext.Session.GetString("login") != "Aucun customer n'est log" && (string)HttpContext.Session.GetString("login") != null) // Need authentification
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Customer");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
