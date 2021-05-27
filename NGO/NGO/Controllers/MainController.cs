using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGO.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Donation()
        {
            return View();
        }

        public IActionResult CauseDetail()
        {
            return View();
        }

        public IActionResult EventDetail()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
