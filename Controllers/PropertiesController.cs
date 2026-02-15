using Microsoft.AspNetCore.Mvc;

namespace VillaAgency.Controllers
{
    public class PropertiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
