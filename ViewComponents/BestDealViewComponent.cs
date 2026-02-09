using Microsoft.AspNetCore.Mvc;

namespace WA_Blog.ViewComponents
{
    public class BestDealViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
