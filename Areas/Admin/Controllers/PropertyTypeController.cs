using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VillaAgency.Areas.Admin.Models;
using VillaAgency.Data;
using VillaAgency.Models.Entities;

namespace VillaAgency.Areas.Admin.Controllers
{
    public class PropertyTypeController : AdminBaseController
    {
        private readonly ApplicationDbContext _context;
        public PropertyTypeController(ApplicationDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            ViewBag.PageTitle = "Property Types";
            var types = await _context.PropertyTypes
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.Name)
                .ToListAsync();
            return View(types);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.PageTitle = "New Property Type";
            return View(new PropertyTypeViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropertyTypeViewModel model)
        {
            if (!ModelState.IsValid) { ViewBag.PageTitle = "New Property Type"; return View(model); }

            _context.PropertyTypes.Add(new PropertyType
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Description = model.Description,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            });
            await _context.SaveChangesAsync();
            TempData["Success"] = "Property type created.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.PageTitle = "Edit Property Type";
            var item = await _context.PropertyTypes.FindAsync(id);
            if (item == null) return NotFound();
            return View(new PropertyTypeViewModel { Id = item.Id, Name = item.Name, Description = item.Description });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PropertyTypeViewModel model)
        {
            if (!ModelState.IsValid) { ViewBag.PageTitle = "Edit Property Type"; return View(model); }
            var item = await _context.PropertyTypes.FindAsync(model.Id);
            if (item == null) return NotFound();
            item.Name = model.Name;
            item.Description = model.Description;
            await _context.SaveChangesAsync();
            TempData["Success"] = "Property type updated.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var item = await _context.PropertyTypes.FindAsync(id);
            if (item != null) { item.IsDeleted = true; await _context.SaveChangesAsync(); }
            TempData["Success"] = "Property type deleted.";
            return RedirectToAction(nameof(Index));
        }
    }
}
