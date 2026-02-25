using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VillaAgency.Data;
using VillaAgency.Models.Entities;

namespace VillaAgency.ViewComponents
{
    public class VideoSectionViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public VideoSectionViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var settings = await _context.SiteSettings
                .FirstOrDefaultAsync(x => x.IsActive && !x.IsDeleted);

            if (settings == null)
            {
                settings = new SiteSetting 
                { 
                    VideoUrl = "https://www.youtube.com/watch?v=7HKq20ihNAU"
                };
            }

            return View(settings);
        }
    }
}
