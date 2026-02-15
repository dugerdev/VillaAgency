using Microsoft.AspNetCore.Mvc;

namespace VillaAgency.ViewComponents
{
    public class VideoSectionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
