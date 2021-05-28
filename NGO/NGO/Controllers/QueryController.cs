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
    public class QueryController : Controller
    {
        private readonly NGOContext _context;

        public QueryController()
        {
            _context ??= new NGOContext();
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Query
        public async Task<IActionResult> List()
        {
            return View(await _context.Queries.ToListAsync());
        }

        // GET: Query/AddOrEdit
        // GET: Query/AddOrEdit/5
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return base.View(new Query());
            }
            else
            {
                var Query = await _context.Queries.FindAsync(id);
                if (Query == null)
                {
                    return NotFound();
                }
                return View(Query);
            }
        }

        // POST: Query/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Id,MemberId,ContentQuery,ReplyTo,Active")] Query query)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(query);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(query);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!QueryExists(query.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewString(this, "_ViewAll", _context.Queries.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewString(this, "AddOrEdit", query) });
        }

        // POST: Query/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Query = await _context.Queries.FindAsync(id);
            _context.Queries.Remove(Query);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewString(this, "_ViewAll", _context.Queries.ToList()) });
        }

        private bool QueryExists(int id)
        {
            return _context.Queries.Any(e => e.Id == id);
        }
    }
}
