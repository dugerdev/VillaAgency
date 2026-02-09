using Microsoft.AspNetCore.Mvc;

namespace WA_Blog.ViewComponents
{
    public class FunFactsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
