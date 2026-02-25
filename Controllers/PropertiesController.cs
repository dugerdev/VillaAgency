using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VillaAgency.Data;
using VillaAgency.Models.Entities;

namespace VillaAgency.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PropertiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1, Guid? categoryId = null)
        {
            var query = _context.Properties
                .Include(p => p.PropertyType)
                .Include(p => p.PropertyImages)
                .Where(p => p.IsActive && !p.IsDeleted)
                .AsQueryable();

            if (categoryId.HasValue)
            {
                query = query.Where(p => p.PropertyTypeId == categoryId.Value);
                ViewBag.SelectedCategory = categoryId.Value;
            }

            int pageSize = 9;
            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var properties = await query
                .OrderByDescending(p => p.CreatedDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.Categories = await _context.PropertyTypes
                                    .Where(x => x.IsActive && !x.IsDeleted)
                                    .ToListAsync();

            return View(properties);
        }
    }
}
