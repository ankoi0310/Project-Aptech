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
    public class MemberTypeController : Controller
    {
        private readonly NGOContext _context;

        public MemberTypeController()
        {
            _context ??= new NGOContext();
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: MemberType
        public async Task<IActionResult> List()
        {
            return View(await _context.MemberTypes.ToListAsync());
        }

        // GET: MemberType/AddOrEdit
        // GET: MemberType/AddOrEdit/5
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return base.View(new MemberType());
            }
            else
            {
                var memberType = await _context.MemberTypes.FindAsync(id);
                if (memberType == null)
                {
                    return NotFound();
                }
                return View(memberType);
            }
        }

        // POST: MemberType/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Id,Name,Active")] MemberType memberType)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(memberType);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(memberType);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!MemberTypeExists(memberType.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewString(this, "_ViewAll", _context.MemberTypes.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewString(this, "AddOrEdit", memberType) });
        }

        // POST: MemberType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var memberType = await _context.MemberTypes.FindAsync(id);
            _context.MemberTypes.Remove(memberType);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewString(this, "_ViewAll", _context.MemberTypes.ToList()) });
        }

        private bool MemberTypeExists(int id)
        {
            return _context.MemberTypes.Any(e => e.Id == id);
        }
    }
}
