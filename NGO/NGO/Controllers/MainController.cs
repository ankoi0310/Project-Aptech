using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult ListProgram()
        {
            var now = DateTime.Now;
            var listPro = _context.Programs.ToList();
            var listTopPro = _context.Programs.Where(x=> DateTime.Compare(x.BeginDate,now)<=0 && DateTime.Compare(x.EndDate, now)>=0)
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
            var listDonationRecord = _context.DonationRecords.Where(x=>x.ProgramId == Id).ToList();
            ViewBag.ListDonationRecord = listDonationRecord;
            var listImage = _context.ProgramImages.ToList();
            ViewBag.listImage = listImage;
            var listDonationCate = _context.DonationCategories.ToList();
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

        public IActionResult Information()
        {
            return View();
        }
    }
}
