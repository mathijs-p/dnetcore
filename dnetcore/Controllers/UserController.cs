using dnetcore.Data;
using dnetcore.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace dnetcore.Controllers
{
    public class UserController : Controller
    {
        private readonly MarketContext _context;
        public UserController(MarketContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> ProcessLogin(UserViewModel userViewModel)
        {
            var user = _context.Users.Where(u => u.Username == userViewModel.Username && u.Password == userViewModel.Password).FirstOrDefault();
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddSeconds(20),
                    IssuedUtc = DateTimeOffset.UtcNow,
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return Redirect("/Home");
            }

            return Redirect("/User/Login");
        }

        public async Task<IActionResult> ProcessLogout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("User/Login");
        }
    }
}
