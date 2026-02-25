using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VillaAgency.Data;

namespace VillaAgency.ViewComponents
{
    public class BestDealViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public BestDealViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var bestDeals = await _context.PropertyTypes
                .Include(pt => pt.Properties.Where(p => p.IsActive && !p.IsDeleted))
                .Where(pt => pt.IsActive && !pt.IsDeleted && pt.Properties.Any())
                .ToListAsync();

            return View(bestDeals);
        }
    }
}
