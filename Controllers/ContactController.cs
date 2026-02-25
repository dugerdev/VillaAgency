using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VillaAgency.Data;
using VillaAgency.Models.Entities;

namespace VillaAgency.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
             var settings = await _context.SiteSettings.FirstOrDefaultAsync(x => x.IsActive && !x.IsDeleted);
             return View(settings);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Contact contact)
        {
            if (contact == null)
            {
                TempData["Error"] = "Invalid request.";
                return RedirectToAction("Index");
            }
            
            // Manuel validasyon (gerekirse ModelState.IsValid'e de güvenilebilir)
            if (string.IsNullOrWhiteSpace(contact.FullName) || string.IsNullOrWhiteSpace(contact.Email))
            {
                 TempData["Error"] = "Name and Email are required fields.";
                 return RedirectToAction("Index");
            }

            try
            {
                contact.Id = Guid.NewGuid();
                contact.CreatedDate = DateTime.Now;
                contact.IsActive = true;
                contact.IsDeleted = false;
                contact.IsRead = false;

                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();

                TempData["Message"] = "Thank you! Your message has been sent successfully. We will contact you soon.";
            }
            catch (Exception ex)
            {
                // Logla...
                TempData["Error"] = "An error occurred while sending your message. Please try again later.";
            }

            return RedirectToAction("Index");

        }
    }
}
