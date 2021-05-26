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
    public class MemberController : Controller
    {
        private readonly NGOContext _context;

        public MemberController()
        {
            _context = _context == null ? new NGOContext() : _context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Member
        public async Task<IActionResult> List()
        {
            return View(await _context.Members.ToListAsync());
        }

        // GET: Member/AddOrEdit
        // GET: Member/AddOrEdit/5
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return base.View(new Member());
            }
            else
            {
                var member = await _context.Members.FindAsync(id);
                if (member == null)
                {
                    return NotFound();
                }
                return View(member);
            }
        }

        // POST: Member/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Id,Name,Phone,Email,BankAccount,BankName,Username,Password,MemberTypeId,Active")] Member member)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    member.Active = true;
                    _context.Add(member);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(member);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!MemberExists(member.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewString(this, "_ViewAll", _context.Members.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewString(this, "AddOrEdit", member) });
        }

        // POST: Member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Member = await _context.Members.FindAsync(id);
            _context.Members.Remove(Member);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewString(this, "_ViewAll", _context.Members.ToList()) });
        }

        private bool MemberExists(int id)
        {
            return _context.Members.Any(e => e.Id == id);
        }
    }
}
