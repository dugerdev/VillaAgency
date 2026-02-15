using Microsoft.AspNetCore.Mvc;

namespace VillaAgency.ViewComponents
{
    public class HomePropertiesViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
