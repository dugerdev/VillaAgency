using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VillaAgency.Data;

namespace VillaAgency.ViewComponents
{
    public class BannerViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public BannerViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var banners = await _context.Banners
                .Where(x => x.IsActive && !x.IsDeleted)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();

            return View(banners);
        }
    }
}
