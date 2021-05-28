using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NGO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGO.Controllers
{
    public class LoginController : Controller
    {
        private readonly NGOContext _context;

        public LoginController()
        {
            _context ??= new NGOContext();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var member = _context.Members.Where(a => a.Username.Equals(username) && a.Password.Equals(password)).FirstOrDefault();
                if (member != null)
                {
                    HttpContext.Session.SetString("MEMBER", JsonConvert.SerializeObject(member));
                    if (Tools.GetMemberType(member.MemberTypeId).Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    return RedirectToAction("Index", "Main");
                }
                else
                {
                    ViewBag.MEMBER = null;
                }
            }

            return RedirectToAction("Index", "Login", ViewBag.MEMBER = null);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("MEMBER");
            return RedirectToAction("Index", "Main");
        }
    }
}
