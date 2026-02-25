using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VillaAgency.Data;
using VillaAgency.Models.ViewModels;

namespace VillaAgency.ViewComponents
{
    public class FeaturedViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public FeaturedViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var featuredProperty = await _context.Properties
                .Include(x => x.PropertyImages)
                .Include(x => x.PropertyType)
                .Where(x => x.IsActive && !x.IsDeleted && x.IsFeatured)
                .FirstOrDefaultAsync();
            
            if (featuredProperty == null)
            {
                featuredProperty = await _context.Properties
                    .Include(x => x.PropertyImages)
                    .Include(x => x.PropertyType)
                    .Where(x => x.IsActive && !x.IsDeleted)
                    .OrderByDescending(x => x.CreatedDate)
                    .FirstOrDefaultAsync();
            }

            var faqs = await _context.FAQs
                .Where(x => x.IsActive && !x.IsDeleted)
                .Take(3)
                .ToListAsync();

            var model = new FeaturedViewModel
            {
                FeaturedProperty = featuredProperty,
                FAQs = faqs ?? new List<VillaAgency.Models.Entities.FAQ>() 
            };

            return View(model);
        }
    }
}
