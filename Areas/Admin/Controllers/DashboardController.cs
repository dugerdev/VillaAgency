using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VillaAgency.Data;

namespace VillaAgency.Areas.Admin.Controllers
{
    public class DashboardController : AdminBaseController
    {
        private readonly ApplicationDbContext _context;
        public DashboardController(ApplicationDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            ViewBag.PageTitle = "Dashboard";
            ViewBag.TotalProperties    = await _context.Properties.CountAsync(x => !x.IsDeleted);
            ViewBag.TotalPropertyTypes = await _context.PropertyTypes.CountAsync(x => !x.IsDeleted);
            ViewBag.TotalFAQs          = await _context.FAQs.CountAsync(x => !x.IsDeleted);
            ViewBag.TotalBanners       = await _context.Banners.CountAsync(x => !x.IsDeleted);
            ViewBag.UnreadMessages     = await _context.Contacts.CountAsync(x => !x.IsDeleted && !x.IsRead);
            ViewBag.TotalMessages      = await _context.Contacts.CountAsync(x => !x.IsDeleted);
            ViewBag.FeaturedProperties = await _context.Properties.CountAsync(x => !x.IsDeleted && x.IsFeatured);
            return View();
        }
    }
}
