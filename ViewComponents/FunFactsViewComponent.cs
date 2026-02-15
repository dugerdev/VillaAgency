using Microsoft.AspNetCore.Mvc;

namespace VillaAgency.ViewComponents
{
    public class FunFactsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
