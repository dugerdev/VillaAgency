using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VillaAgency.Data;
using VillaAgency.Models.Entities;

namespace VillaAgency.Controllers
{
    public class PropertyDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PropertyDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(Guid id)
        {
            if (id == Guid.Empty)
            {
                 var firstProperty = await _context.Properties
                    .Include(p => p.PropertyType)
                    .Include(p => p.PropertyImages)
                    .FirstOrDefaultAsync(p => p.IsActive && !p.IsDeleted);

                 if(firstProperty == null) return NotFound();
                 
                 return View(firstProperty);
            }

            var property = await _context.Properties
                .Include(p => p.PropertyType)
                .Include(p => p.PropertyImages)
                .FirstOrDefaultAsync(p => p.Id == id && p.IsActive && !p.IsDeleted);

            if (property == null) return NotFound();

            return View(property);
        }
    }
}
