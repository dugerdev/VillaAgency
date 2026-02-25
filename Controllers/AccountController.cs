using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using VillaAgency.Models.Entities;
using VillaAgency.Models.ViewModels;


namespace VillaAgency.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppilcationUser> _signInManager;
        private readonly UserManager<AppilcationUser> _userManager;
        public AccountController(SignInManager<AppilcationUser> signInManager, UserManager<AppilcationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }

            ModelState.AddModelError("", "Invalid login attempt (Email or Password Incorrect)");

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home", new { area = "" });

        }

        public IActionResult AccesDenied()
        {
            return View();
        }
    }
}
