using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NGO.Models;
using NGO.Models.MappingClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGO.Controllers
{
    public class MainController : Controller
    {
        private readonly NGOContext _context;

        public MainController()
        {
            _context ??= new NGOContext();
        }

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

        public async Task<IActionResult> Update([Bind("Id,Name,Phone,Email,BankAccount,BankName,Username,Password,MemberTypeId,Active")] Member member)
        {
            if (ModelState.IsValid)
            {
                Member oldMember = await _context.Members.FindAsync(member.Id);
                oldMember.Name = member.Name ?? oldMember.Name; 
                oldMember.Phone = member.Phone ?? oldMember.Phone; 
                oldMember.Email = member.Email ?? oldMember.Email; 
                oldMember.BankAccount = member.BankAccount ?? oldMember.BankAccount; 
                oldMember.BankName = member.BankName ?? oldMember.BankName;
                HttpContext.Session.SetString("MEMBER", JsonConvert.SerializeObject(oldMember));
                _context.Update(oldMember);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("information");
        }


        public IActionResult ListProgram(int id)
        {
            var now = DateTime.Now;
            List<NGO.Models.MappingClass.Program> listPro = new List<NGO.Models.MappingClass.Program>();
            if (id == 0)
            {
                listPro = _context.Programs.ToList();
            }
            else
            {
                listPro = _context.Programs.Where(x => x.DonationCategoryId == id).ToList();
            }

            var listTopPro = _context.Programs.Where(x => DateTime.Compare(x.BeginDate, now) <= 0 && DateTime.Compare(x.EndDate, now) >= 0)
                .OrderByDescending(x => x.NeedAmount).ToList();

            if (listTopPro.Count >= 5)
            {
                listTopPro = listTopPro.Take(5).ToList();
            }
            var listImage = _context.ProgramImages.ToList();
            var listDonationCate = _context.DonationCategories.ToList();
            var listDonationRecord = _context.DonationRecords.ToList();
            ViewBag.ListProgram = listPro;
            ViewBag.ListTopProgram = listTopPro;
            ViewBag.listImage = listImage;
            ViewBag.ListDonationCate = listDonationCate;
            ViewBag.ListDonationRecord = listDonationRecord;
            return View();
        }
        public IActionResult ProgramDetail(int Id)
        {
            Models.MappingClass.Program pro = _context.Programs.Find(Id);
            ViewBag.Program = pro;
            var listDonationRecord = _context.DonationRecords.Where(x => x.ProgramId == Id).ToList();
            ViewBag.ListDonationRecord = listDonationRecord;
            var listImage = _context.ProgramImages.ToList();
            ViewBag.listImage = listImage;
            var listPayment = _context.PaymentTypes.ToList();
            ViewBag.listPayment = listPayment;
            var listDonationCate = _context.DonationCategories.ToList();

            var memberString = HttpContext.Session.GetString("MEMBER");

            if (memberString != null)
            {
                ViewBag.Member = JsonConvert.DeserializeObject<Member>(memberString);
            }
            return View();
        }

        [HttpPost]
        public IActionResult MakeDonation(DonationRecord donationRecord)
        {
            try
            {
                donationRecord.PaymentTypeId = int.Parse(Request.Form["radio-group"]);
                donationRecord.Date = DateTime.Now;
                donationRecord.Active = true;
                _context.DonationRecords.Add(donationRecord);
                var result = _context.SaveChanges();
                if (result > 0)
                {
                    TempData["Mess"] = "Your donation is made successful";
                    return RedirectToAction("transaction", new { id = donationRecord.MemberId });
                }
                else
                {
                    TempData["Mess"] = "Your form is filled incorrectly";
                    return RedirectToAction("ProgramDetail", new { id = donationRecord.ProgramId });
                }
            }
            catch (Exception)
            {
                TempData["Mess"] = "Your form should have filled out"; ;
                return RedirectToAction("ProgramDetail", new { id = donationRecord.ProgramId });
            }

        }

        public IActionResult EventDetail()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Information()
        {
            if (HttpContext.Session.GetString("MEMBER") != null)
            {
                Member member = JsonConvert.DeserializeObject<Member>(HttpContext.Session.GetString("MEMBER"));
                return View(member);
            }
            return View();
        }

        public IActionResult Transaction(int id)
        {
            var listTransaction = _context.DonationRecords.Where(x => x.MemberId == id).ToList();
            ViewBag.listTransaction = listTransaction;

            string memberString = HttpContext.Session.GetString("MEMBER");

            if (memberString != null)
            {
                ViewBag.Member = JsonConvert.DeserializeObject<Member>(memberString);
            }
            var program = _context.Programs.ToList();
            var payment = _context.PaymentTypes.ToList();
            return View();
        }
    }
}
