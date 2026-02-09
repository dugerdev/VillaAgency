using Microsoft.AspNetCore.Mvc;

namespace WA_Blog.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
