using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VillaAgency.Data;
using VillaAgency.Models.ViewModels;

namespace VillaAgency.ViewComponents
{
    public class FunFactsViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public FunFactsViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int totalProperties = await _context.Properties.CountAsync(x => x.IsActive && !x.IsDeleted);
            
            // IsSold alanı olmadığı için varsayılan bir mantık
            int soldProperties = (int)(totalProperties * 0.3);

            var model = new FunFactsViewModel
            {
                TotalProperties = totalProperties,
                SoldProperties = soldProperties,
                TotalAwards = 12,
                YearsExperience = 12
            };

            return View(model);
        }
    }
}
