using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VillaAgency.Areas.Admin.Models;
using VillaAgency.Data;
using VillaAgency.Models.Entities;

namespace VillaAgency.Areas.Admin.Controllers
{
    public class PropertyController : AdminBaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public PropertyController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.PageTitle = "Properties";
            var properties = await _context.Properties
                .Include(p => p.PropertyType)
                .Include(p => p.PropertyImages)
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.CreatedDate)
                .ToListAsync();
            return View(properties);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.PageTitle = "New Property";
            var model = new PropertyCreateViewModel
            {
                PropertyTypes = await GetPropertyTypesSelectList()
            };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropertyCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.PropertyTypes = await GetPropertyTypesSelectList();
                ViewBag.PageTitle = "New Property";
                return View(model);
            }

            var property = new Property
            {
                Id = Guid.NewGuid(),
                Tittle = model.Title,
                Description = model.Description,
                Price = model.Price,
                Address = model.Address,
                City = model.City,
                State = model.State,
                ZipCode = model.ZipCode,
                Bathrooms = model.Bathrooms,
                BedRooms = model.BedRooms,
                Area = model.Area,
                Floor = model.Floor,
                Parking = model.Parking,
                TotalFlatSpace = model.TotalFlatSpace,
                IsFeatured = model.IsFeatured,
                IsContractReady = model.IsContractReady,
                PaymentProcess = model.PaymentProcess,
                VideoUrl = model.VideoUrl,
                PropertyTypeId = model.PropertyTypeId,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            };

            if (model.Images != null && model.Images.Any())
            {
                property.PropertyImages = await SaveImages(model.Images, property.Id);
            }

            _context.Properties.Add(property);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Property created successfully.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.PageTitle = "Edit Property";
            var property = await _context.Properties
                .Include(p => p.PropertyImages)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
            if (property == null) return NotFound();

            var model = new PropertyEditViewModel
            {
                Id = property.Id,
                Title = property.Tittle,
                Description = property.Description,
                Price = property.Price,
                Address = property.Address,
                City = property.City,
                State = property.State,
                ZipCode = property.ZipCode,
                Bathrooms = property.Bathrooms,
                BedRooms = property.BedRooms,
                Area = property.Area,
                Floor = property.Floor,
                Parking = property.Parking,
                TotalFlatSpace = property.TotalFlatSpace,
                IsFeatured = property.IsFeatured,
                IsContractReady = property.IsContractReady,
                PaymentProcess = property.PaymentProcess,
                VideoUrl = property.VideoUrl,
                PropertyTypeId = property.PropertyTypeId,
                ExistingImages = property.PropertyImages.ToList(),
                PropertyTypes = await GetPropertyTypesSelectList()
            };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PropertyEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.PropertyTypes = await GetPropertyTypesSelectList();
                model.ExistingImages = await _context.PropertyImages.Where(x => x.PropertyId == model.Id).ToListAsync();
                ViewBag.PageTitle = "Edit Property";
                return View(model);
            }

            var property = await _context.Properties
                .Include(p => p.PropertyImages)
                .FirstOrDefaultAsync(p => p.Id == model.Id);
            if (property == null) return NotFound();

            property.Tittle = model.Title;
            property.Description = model.Description;
            property.Price = model.Price;
            property.Address = model.Address;
            property.City = model.City;
            property.State = model.State;
            property.ZipCode = model.ZipCode;
            property.Bathrooms = model.Bathrooms;
            property.BedRooms = model.BedRooms;
            property.Area = model.Area;
            property.Floor = model.Floor;
            property.Parking = model.Parking;
            property.TotalFlatSpace = model.TotalFlatSpace;
            property.IsFeatured = model.IsFeatured;
            property.IsContractReady = model.IsContractReady;
            property.PaymentProcess = model.PaymentProcess;
            property.VideoUrl = model.VideoUrl;
            property.PropertyTypeId = model.PropertyTypeId;

            if (model.NewImages != null && model.NewImages.Any())
            {
                var newImages = await SaveImages(model.NewImages, property.Id);
                foreach (var img in newImages)
                    _context.PropertyImages.Add(img);
            }

            await _context.SaveChangesAsync();
            TempData["Success"] = "Property updated successfully.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var property = await _context.Properties.FindAsync(id);
            if (property != null) { property.IsDeleted = true; await _context.SaveChangesAsync(); }
            TempData["Success"] = "Property deleted.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteImage(Guid imageId, Guid propertyId)
        {
            var image = await _context.PropertyImages.FindAsync(imageId);
            if (image != null)
            {
                var filePath = Path.Combine(_env.WebRootPath, image.ImageUrl.TrimStart('/'));
                if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);
                _context.PropertyImages.Remove(image);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Edit), new { id = propertyId });
        }

        // ---- Helpers ----
        private async Task<List<SelectListItem>> GetPropertyTypesSelectList() =>
            (await _context.PropertyTypes.Where(x => x.IsActive && !x.IsDeleted).OrderBy(x => x.Name).ToListAsync())
            .Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name }).ToList();

        private async Task<List<PropertyImage>> SaveImages(List<IFormFile> files, Guid propertyId)
        {
            var images = new List<PropertyImage>();
            var folder = Path.Combine(_env.WebRootPath, "uploads", "properties");
            Directory.CreateDirectory(folder);
            foreach (var file in files.Where(f => f.Length > 0))
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                var fullPath = Path.Combine(folder, fileName);
                using var stream = new FileStream(fullPath, FileMode.Create);
                await file.CopyToAsync(stream);
                images.Add(new PropertyImage
                {
                    Id = Guid.NewGuid(),
                    PropertyId = propertyId,
                    ImageUrl = $"/uploads/properties/{fileName}",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                });
            }
            return images;
        }
    }
}
