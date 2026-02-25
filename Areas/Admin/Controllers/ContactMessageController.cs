using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VillaAgency.Data;

namespace VillaAgency.Areas.Admin.Controllers
{
    public class ContactMessageController : AdminBaseController
    {
        private readonly ApplicationDbContext _context;
        public ContactMessageController(ApplicationDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            ViewBag.PageTitle = "Contact Messages";
            var messages = await _context.Contacts
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.CreatedDate)
                .ToListAsync();
            ViewBag.UnreadCount = messages.Count(x => !x.IsRead);
            return View(messages);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid id)
        {
            ViewBag.PageTitle = "Message Detail";
            var message = await _context.Contacts.FindAsync(id);
            if (message == null) return NotFound();

            if (!message.IsRead)
            {
                message.IsRead = true;
                message.ReadDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return View(message);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var message = await _context.Contacts.FindAsync(id);
            if (message != null) { message.IsDeleted = true; await _context.SaveChangesAsync(); }
            TempData["Success"] = "Message deleted.";
            return RedirectToAction(nameof(Index));
        }
    }
}
