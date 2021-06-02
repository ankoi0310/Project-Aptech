using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NGO.Models;
using NGO.Models.MappingClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NGO.Controllers
{
    public class PartnerController : Controller
    {
        private readonly NGOContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PartnerController(IWebHostEnvironment webHostEnvironment)
        {
            _context = _context == null ? new NGOContext() : _context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Partner
        public async Task<IActionResult> List()
        {
            return View(await _context.Partners.ToListAsync());
        }

        // GET: Partner/AddOrEdit
        // GET: Partner/AddOrEdit/5
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return base.View(new Partner());
            }
            else
            {
                var Partner = await _context.Partners.FindAsync(id);
                if (Partner == null)
                {
                    return NotFound();
                }
                return View(Partner);
            }
        }

        // POST: Partner/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Id,Name,Address,Information,ImageFile,Active")] Partner partner)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = null;
                string path = null;
                if (partner.ImageFile != null)
                {
                    fileName = Path.GetFileNameWithoutExtension(partner.ImageFile.FileName);
                    string extension = Path.GetExtension(partner.ImageFile.FileName);
                    partner.LogoImage = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    path = Path.Combine(wwwRootPath + "/assetsAdmin/images/partners", fileName);
                }
                if (id == 0)
                {
                    using (var fs = new FileStream(path, FileMode.Create))
                    {
                        await partner.ImageFile.CopyToAsync(fs);
                    }
                    partner.Active = true;
                    _context.Add(partner);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        if (fileName != null)
                        {
                            using (var fs = new FileStream(path, FileMode.Create))
                            {
                                await partner.ImageFile.CopyToAsync(fs);
                            }
                        } else
                        {
                            partner.LogoImage = _context.Partners.AsNoTracking().FirstOrDefault(p => p.Id == partner.Id).LogoImage;
                        }
                        _context.Update(partner);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!PartnerExists(partner.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewString(this, "_ViewAll", _context.Partners.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewString(this, "AddOrEdit", partner) });
        }

        // POST: Partner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Partner = await _context.Partners.FindAsync(id);
            DeleteImage(Partner);
            _context.Partners.Remove(Partner);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewString(this, "_ViewAll", _context.Partners.ToList()) });
        }

        private bool PartnerExists(int id)
        {
            return _context.Partners.Any(e => e.Id == id);
        }

        public void DeleteImage(Partner p)
        {
            if (p.Id != 0)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                System.IO.File.Delete(wwwRootPath + "/assetsAdmin/images/partners/" + p.LogoImage);
            }
        }
    }
}
