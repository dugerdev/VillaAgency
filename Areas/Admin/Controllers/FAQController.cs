using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VillaAgency.Areas.Admin.Models;
using VillaAgency.Data;
using VillaAgency.Models.Entities;

namespace VillaAgency.Areas.Admin.Controllers
{
    public class FAQController : AdminBaseController
    {
        private readonly ApplicationDbContext _context;
        public FAQController(ApplicationDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            ViewBag.PageTitle = "FAQs";
            var faqs = await _context.FAQs
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();
            return View(faqs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.PageTitle = "New FAQ";
            return View(new FAQViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FAQViewModel model)
        {
            if (!ModelState.IsValid) { ViewBag.PageTitle = "New FAQ"; return View(model); }
            _context.FAQs.Add(new FAQ
            {
                Id = Guid.NewGuid(),
                Question = model.Question,
                Answer = model.Answer,
                DisplayOrder = model.DisplayOrder,
                IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now
            });
            await _context.SaveChangesAsync();
            TempData["Success"] = "FAQ created.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.PageTitle = "Edit FAQ";
            var faq = await _context.FAQs.FindAsync(id);
            if (faq == null) return NotFound();
            return View(new FAQViewModel { Id = faq.Id, Question = faq.Question, Answer = faq.Answer, DisplayOrder = faq.DisplayOrder });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FAQViewModel model)
        {
            if (!ModelState.IsValid) { ViewBag.PageTitle = "Edit FAQ"; return View(model); }
            var faq = await _context.FAQs.FindAsync(model.Id);
            if (faq == null) return NotFound();
            faq.Question = model.Question;
            faq.Answer = model.Answer;
            faq.DisplayOrder = model.DisplayOrder;
            await _context.SaveChangesAsync();
            TempData["Success"] = "FAQ updated.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var faq = await _context.FAQs.FindAsync(id);
            if (faq != null) { faq.IsDeleted = true; await _context.SaveChangesAsync(); }
            TempData["Success"] = "FAQ deleted.";
            return RedirectToAction(nameof(Index));
        }
    }
}
