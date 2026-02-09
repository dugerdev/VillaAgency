using Microsoft.AspNetCore.Mvc;

namespace WA_Blog.ViewComponents
{
    public class VideoSectionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
