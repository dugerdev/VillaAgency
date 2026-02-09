using Microsoft.AspNetCore.Mvc;

namespace WA_Blog.Controllers
{
    public class PropertiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
