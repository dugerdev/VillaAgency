using Microsoft.AspNetCore.Mvc;

namespace WA_Blog.ViewComponents
{
    public class HomePropertiesViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
