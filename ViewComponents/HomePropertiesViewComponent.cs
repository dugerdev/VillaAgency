using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VillaAgency.Data;
using VillaAgency.Models.Entities;

namespace VillaAgency.ViewComponents
{
    public class HomePropertiesViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public HomePropertiesViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var properties = await _context.Properties
                .Include(x => x.PropertyType)
                .Include(x => x.PropertyImages)
                .Where(x => x.IsActive && !x.IsDeleted)
                .OrderByDescending(x => x.CreatedDate)
                .Take(6)
                .ToListAsync();

            return View(properties);
        }
    }
}
