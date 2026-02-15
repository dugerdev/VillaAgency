using Microsoft.AspNetCore.Mvc;

namespace VillaAgency.ViewComponents
{
    public class BestDealViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
