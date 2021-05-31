using Microsoft.AspNetCore.Mvc;
using NGO.Models;
using NGO.Models.MappingClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGO.Controllers
{
    public class RegisterController : Controller
    {
        private readonly NGOContext _context;

        public RegisterController()
        {
            _context ??= new NGOContext();
        }
        public IActionResult Index()
        {
            return View();
        }

        // POST: Member/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int id, [Bind("Id,Name,Phone,Email,BankAccount,BankName,Username,Password, MemberTypeId, Active")] Member member)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    if (!MemberExists(member.Username, member.BankAccount))
                    {
                        member.MemberTypeId = _context.MemberTypes.FirstOrDefault(m => m.Name == "member").Id;
                        member.Active = true;
                        _context.Add(member);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        ViewBag.Message = "Username or Bank Account existed!";
                    }
                }
            }
            return View();
        }
        private bool MemberExists(string username, string bankaccount)
        {
            return _context.Members.Any(e => e.Username == username || e.BankAccount == bankaccount);
        }
    }
}
