using Microsoft.AspNetCore.Mvc;

namespace WA_Blog.ViewComponents
{
    public class ContactSectionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
