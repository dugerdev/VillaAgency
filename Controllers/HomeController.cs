using Microsoft.AspNetCore.Mvc;
using VillaAgency.Data;
using VillaAgency.Models;
using VillaAgency.Models.Entities;

namespace VillaAgency.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
