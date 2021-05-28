using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NGO.Models;
using NGO.Models.MappingClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGO.Controllers
{
    public class DonationCategoryController : Controller
    {
        private readonly NGOContext _context;

        public DonationCategoryController(NGOContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: DonationCategory
        public async Task<IActionResult> List()
        {
            return View(await _context.DonationCategories.ToListAsync());
        }

        // GET: DonationCategory/AddOrEdit
        // GET: DonationCategory/AddOrEdit/5
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return base.View(new DonationCategory());
            }
            else
            {
                var donationCate = await _context.DonationCategories.FindAsync(id);
                if (donationCate == null)
                {
                    return NotFound();
                }
                return View(donationCate);
            }
        }

        // POST: DonationCategory/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Id, Name, Descriptions, Active")] DonationCategory donationCate)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    donationCate.Active = true;
                    _context.Add(donationCate);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(donationCate);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CheckExists(donationCate.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewString(this, "_ViewAll", _context.DonationCategories.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewString(this, "AddOrEdit", donationCate) });
        }

        // POST: DonationCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donationCate = await _context.DonationCategories.FindAsync(id);
            _context.DonationCategories.Remove(donationCate);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewString(this, "_ViewAll", _context.DonationCategories.ToList()) });
        }

        private bool CheckExists(int id)
        {
            return _context.DonationCategories.Any(e => e.Id == id);
        }
    }
}
