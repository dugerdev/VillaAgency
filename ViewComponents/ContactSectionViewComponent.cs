using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VillaAgency.Data;
using VillaAgency.Models.Entities;

namespace VillaAgency.ViewComponents
{
    public class ContactSectionViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ContactSectionViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var settings = await _context.SiteSettings
                .FirstOrDefaultAsync(x => x.IsActive && !x.IsDeleted);

            if (settings == null)
            {
                settings = new SiteSetting
                {
                    MapEmbedUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d12469.776493332698!2d-80.14036379941481!3d25.907788681148624!2m3!1f357.26927939317244!2f20.870722720054623!3f0!3m2!1i1024!2i768!4f35!3m3!1m2!1s0x88d9add4b4ac788f%3A0xe77469d09480fcdb!2sSunny%20Isles%20Beach!5e1!3m2!1sen!2sth!4v1642869952544!5m2!1sen!2sth",
                    PhoneNumber = "010-020-0340",
                    Email = "info@villa.co"
                };
            }

            return View(settings);
        }
    }
}
