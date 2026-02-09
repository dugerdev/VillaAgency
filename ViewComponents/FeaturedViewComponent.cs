using Microsoft.AspNetCore.Mvc;

namespace WA_Blog.ViewComponents
{
    public class FeaturedViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
