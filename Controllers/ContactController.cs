using Microsoft.AspNetCore.Mvc;

namespace VillaAgency.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
