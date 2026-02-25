using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VillaAgency.Areas.Admin.Models;
using VillaAgency.Data;
using VillaAgency.Models.Entities;

namespace VillaAgency.Areas.Admin.Controllers
{
    public class BannerController : AdminBaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BannerController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.PageTitle = "Banners";
            var banners = await _context.Banners
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();
            return View(banners);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.PageTitle = "New Banner";
            return View(new BannerEditViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BannerEditViewModel model)
        {
            if (!ModelState.IsValid) { ViewBag.PageTitle = "New Banner"; return View(model); }

            var banner = new Banner
            {
                Id = Guid.NewGuid(),
                Tittle = model.Title,
                Category = model.Category,
                Description = model.Description,
                DisplayOrder = model.DisplayOrder,
                LinkedinUrl = model.LinkedinUrl,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            };

            if (model.ImageFile != null && model.ImageFile.Length > 0)
                banner.ImageUrl = await SaveFile(model.ImageFile, "banners");

            _context.Banners.Add(banner);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Banner created.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.PageTitle = "Edit Banner";
            var banner = await _context.Banners.FindAsync(id);
            if (banner == null) return NotFound();
            return View(new BannerEditViewModel
            {
                Id = banner.Id,
                Title = banner.Tittle,
                Category = banner.Category,
                Description = banner.Description,
                DisplayOrder = banner.DisplayOrder,
                LinkedinUrl = banner.LinkedinUrl,
                ExistingImageUrl = banner.ImageUrl
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BannerEditViewModel model)
        {
            if (!ModelState.IsValid) { ViewBag.PageTitle = "Edit Banner"; return View(model); }
            var banner = await _context.Banners.FindAsync(model.Id);
            if (banner == null) return NotFound();

            banner.Tittle = model.Title;
            banner.Category = model.Category;
            banner.Description = model.Description;
            banner.DisplayOrder = model.DisplayOrder;
            banner.LinkedinUrl = model.LinkedinUrl;

            if (model.ImageFile != null && model.ImageFile.Length > 0)
                banner.ImageUrl = await SaveFile(model.ImageFile, "banners");

            await _context.SaveChangesAsync();
            TempData["Success"] = "Banner updated.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var banner = await _context.Banners.FindAsync(id);
            if (banner != null) { banner.IsDeleted = true; await _context.SaveChangesAsync(); }
            TempData["Success"] = "Banner deleted.";
            return RedirectToAction(nameof(Index));
        }

        private async Task<string> SaveFile(IFormFile file, string subfolder)
        {
            var folder = Path.Combine(_env.WebRootPath, "uploads", subfolder);
            Directory.CreateDirectory(folder);
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            using var stream = new FileStream(Path.Combine(folder, fileName), FileMode.Create);
            await file.CopyToAsync(stream);
            return $"/uploads/{subfolder}/{fileName}";
        }
    }
}
