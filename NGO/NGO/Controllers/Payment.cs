﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGO.Controllers
{
    public class Payment : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
