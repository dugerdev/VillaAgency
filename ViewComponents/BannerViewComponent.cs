using Microsoft.AspNetCore.Mvc;

namespace WA_Blog.ViewComponents
{
    public class BannerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
