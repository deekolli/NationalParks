using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NationalParks.Models;
using NationalParks.APIHandlerManager;
using Newtonsoft.Json;

namespace NationalParks.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Parks()
        {
            APIHandler webHandler = new APIHandler();
            Parks parks = webHandler.GetParks();

            return View(parks);
        }
       
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult explore ()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
