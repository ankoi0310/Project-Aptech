using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
    public class ProgramImageController : Controller
    {
        private readonly NGOContext _context;
        private readonly IWebHostEnvironment _webHostEnvironmen;
        static int _ProgramId = 0;
        public ProgramImageController(IWebHostEnvironment webHostEnvironmen)
        {
            _context ??= new NGOContext();
            _webHostEnvironmen = webHostEnvironmen;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: ProgramImage
        public async Task<IActionResult> List(int ProgramId)
        {
            _context.Programs.ToList();
            var list = await _context.ProgramImages.Where(x => x.ProgramId == ProgramId).ToListAsync();
            _ProgramId = ProgramId;
            return View(list);

        }

        // GET: ProgramImage/AddMultiImage
        [NoDirectAccess]
        public async Task<IActionResult> AddMultiImage(int id = 0)
        {
            Models.MappingClass.Program pro = await _context.Programs.FindAsync(_ProgramId);
            return base.View(pro);
        }
        // GET: ProgramImage/EditSingleImage
        [NoDirectAccess]
        public async Task<IActionResult> EditSingleImage(int id)
        {
            var image = await _context.ProgramImages.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }
            return View(image);
        }

        // POST: ProgramImage/AddMultiImage/
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMultiImage( Models.MappingClass.Program pro)
        {
            if (ModelState.IsValid)
            {
                List<IFormFile> files = Request.Form.Files.ToList();
                foreach (FormFile formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        if (!CheckNameExist(formFile.FileName))
                        {
                            ProgramImage newImage = new ProgramImage();
                            newImage.Name = formFile.FileName;
                            newImage.Path = UploadFile(formFile);
                            newImage.Active = true;
                            newImage.ProgramId = _ProgramId;
                            _context.Add(newImage);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewString(this, "_ViewAll", _context.ProgramImages.ToList()) });
            }
            return RedirectToAction("List", new { ProgramId = _ProgramId });
        }
        // POST: ProgramImage/EditSingleImage/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSingleImage(int id, Models.MappingClass.Program pro)
        {
            if (ModelState.IsValid)
            {

                ProgramImage image = _context.ProgramImages.Find(id);
                try
                {
                    List<IFormFile> files = Request.Form.Files.ToList();
                    foreach (FormFile formFile in files)
                    {
                        DeleteImage(image);
                        if (!CheckNameExist(formFile.FileName))
                        {
                            image.Name = formFile.FileName;
                            image.Path = UploadFile(formFile);
                        }
                        else
                        {
                            _context.ProgramImages.Remove(image);
                        }
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckExists(image.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return Json(new { isValid = true, html = Helper.RenderRazorViewString(this, "_ViewAll", _context.ProgramImages.ToList()) });
            }
            return RedirectToAction("List", new { ProgramId = _ProgramId });
        }
        // POST: ProgramImage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var image = await _context.ProgramImages.FindAsync(id);
            DeleteImage(image);
            _context.ProgramImages.Remove(image);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewString(this, "_ViewAll", _context.ProgramImages.ToList()) });
        }

        private bool CheckExists(int id)
        {
            return _context.ProgramImages.Any(e => e.Id == id);
        }

        private bool CheckNameExist(string name)
        {
            return _context.ProgramImages.Any(e => e.Name == name);
        }

        private string UploadFile(FormFile file)
        {
            string filePath = null;
            if (file != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironmen.WebRootPath, "assetsAdmin/images/programs");
                string fileName = file.FileName;
                filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return filePath;
        }

        public static void DeleteImage(ProgramImage p)
        {
            if (p.Id != 0)
            {
                System.IO.File.Delete(p.Path);
            }
        }


    }
}
