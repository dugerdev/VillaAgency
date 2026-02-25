using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VillaAgency.Areas.Admin.Models;
using VillaAgency.Data;
using VillaAgency.Models.Entities;

namespace VillaAgency.Areas.Admin.Controllers
{
    public class SiteSettingController : AdminBaseController
    {
        private readonly ApplicationDbContext _context;
        public SiteSettingController(ApplicationDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.PageTitle = "Site Settings";
            var setting = await _context.SiteSettings.FirstOrDefaultAsync(x => !x.IsDeleted);

            if (setting == null)
            {
                return View(new SiteSettingViewModel());
            }

            return View(new SiteSettingViewModel
            {
                Id = setting.Id,
                SiteName = setting.SiteName,
                PhoneNumber = setting.PhoneNumber,
                Email = setting.Email,
                Address = setting.Address,
                MapEmbedUrl = setting.MapEmbedUrl,
                VideoUrl = setting.VideoUrl ?? string.Empty
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(SiteSettingViewModel model)
        {
            if (!ModelState.IsValid) { ViewBag.PageTitle = "Site Settings"; return View(model); }

            var setting = model.Id != Guid.Empty
                ? await _context.SiteSettings.FindAsync(model.Id)
                : null;

            if (setting == null)
            {
                _context.SiteSettings.Add(new SiteSetting
                {
                    Id = Guid.NewGuid(),
                    SiteName = model.SiteName,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Address = model.Address,
                    MapEmbedUrl = model.MapEmbedUrl,
                    VideoUrl = model.VideoUrl,
                    IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now
                });
            }
            else
            {
                setting.SiteName = model.SiteName;
                setting.PhoneNumber = model.PhoneNumber;
                setting.Email = model.Email;
                setting.Address = model.Address;
                setting.MapEmbedUrl = model.MapEmbedUrl;
                setting.VideoUrl = model.VideoUrl;
            }

            await _context.SaveChangesAsync();
            TempData["Success"] = "Site settings saved.";
            return RedirectToAction(nameof(Index));
        }
    }
}
