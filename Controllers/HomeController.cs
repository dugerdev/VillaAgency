using Microsoft.AspNetCore.Mvc;

namespace WA_Blog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
