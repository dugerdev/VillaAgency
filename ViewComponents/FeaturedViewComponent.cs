using Microsoft.AspNetCore.Mvc;

namespace VillaAgency.ViewComponents
{
    public class FeaturedViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
