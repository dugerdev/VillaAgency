using Microsoft.AspNetCore.Mvc;

namespace VillaAgency.ViewComponents
{
    public class ContactSectionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
