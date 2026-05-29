using System.Security.Claims;
using Book_Shop.Db;
using Book_Shop.Enums;
using Book_Shop.Models;
using Book_Shop.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Book_Shop.Controllers
{
   
    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = FakeDb.users.FirstOrDefault(x => x.Name == model.Username && x.Password == model.Password);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new(ClaimTypes.Name, model.Username),
                    new(ClaimTypes.Role, ((RoleEnum)user.RoleId).ToString())
                };

                var identity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Book");
            }

            ModelState.AddModelError("", "İstifadəçi adı və ya şifrə yanlışdır");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }
    }
}
