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
    public class ProgramController : Controller
    {
        private readonly NGOContext _context;

        public ProgramController(NGOContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Program
        public async Task<IActionResult> List()
        {
            ViewBag.StatusList = _context.Status.ToList();
            ViewBag.DonationCateList = _context.DonationCategories.ToList();

            return View(await _context.Programs.ToListAsync());
        }

        // GET: Program/AddOrEdit
        // GET: Program/AddOrEdit/5
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            ViewBag.StatusList = _context.Status.ToList();
            ViewBag.DonationCateList = _context.DonationCategories.ToList();
            if (id == 0)
            {
                return base.View(new Models.MappingClass.Program());
            }
            else
            {
                var pro = await _context.Programs.FindAsync(id);
                if (pro == null)
                {
                    return NotFound();
                }
                return View(pro);
            }
        }

        // POST: Program/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, Models.MappingClass.Program pro)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    pro.Active = true;
                    _context.Add(pro);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(pro);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CheckExists(pro.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewString(this, "_ViewAll", _context.Programs.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewString(this, "AddOrEdit", pro) });
        }

        // POST: Program/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pro = await _context.Programs.FindAsync(id);
            var listImage = _context.ProgramImages.Where(x => x.ProgramId == id).ToList();
            _context.Programs.Remove(pro);
            if (listImage != null)
            {
                foreach (var item in listImage)
                {
                    ProgramImageController.DeleteImage(item);
                }
                _context.ProgramImages.RemoveRange(listImage);
            }
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewString(this, "_ViewAll", _context.Programs.ToList()) });
        }

        private bool CheckExists(int id)
        {
            return _context.Programs.Any(e => e.Id == id);
        }

    }
}
