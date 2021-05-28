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
    public class PaymentTypeController : Controller
    {
        private readonly NGOContext _context;

        public PaymentTypeController()
        {
            _context = _context == null ? new NGOContext() : _context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: PaymentType
        public async Task<IActionResult> List()
        {
            return View(await _context.PaymentTypes.ToListAsync());
        }

        // GET: PaymentType/AddOrEdit
        // GET: PaymentType/AddOrEdit/5
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return base.View(new PaymentType());
            }
            else
            {
                var PaymentType = await _context.PaymentTypes.FindAsync(id);
                if (PaymentType == null)
                {
                    return NotFound();
                }
                return View(PaymentType);
            }
        }

        // POST: PaymentType/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Id,Name,Descriptions,Active")] PaymentType PaymentType)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    PaymentType.Active = true;
                    _context.Add(PaymentType);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(PaymentType);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!PaymentTypeExists(PaymentType.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewString(this, "_ViewAll", _context.PaymentTypes.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewString(this, "AddOrEdit", PaymentType) });
        }

        // POST: PaymentType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var PaymentType = await _context.PaymentTypes.FindAsync(id);
            _context.PaymentTypes.Remove(PaymentType);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewString(this, "_ViewAll", _context.PaymentTypes.ToList()) });
        }

        private bool PaymentTypeExists(int id)
        {
            return _context.PaymentTypes.Any(e => e.Id == id);
        }
    }
}
