using Microsoft.AspNetCore.Mvc;

namespace VillaAgency.ViewComponents
{
    public class BannerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
