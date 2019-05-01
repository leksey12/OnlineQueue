using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DAL_OnlineQueue.EFContext;
using DAL_OnlineQueue.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineQueue.ViewModels;

namespace OnlineQueue.Controllers
{
    /// <summary>
    /// Регистрация и авторизация  
    /// </summary>
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationDbContext db;

        public AccountController(ApplicationDbContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            if (User != null && User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // ищем юзера в  базе данных по логин+пароль
                UserData user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

                //если находим
                if (user != null)
                {
                    //авторизуемся
                    await Authenticate(user.Email);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректный логин/Пароль");

            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            if (User != null && User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            //проверяем модель
            if (ModelState.IsValid)
            {
                // проверяем  логин в базе
                UserData user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

                if (user == null)
                {
                    db.Users.Add(new UserData { Email = model.Email, Name = model.Name, Password = model.Password });
                    await db.SaveChangesAsync();
                    await Authenticate(model.Email);
                    return RedirectToAction("Index", "Home");
                }
                else ModelState.AddModelError("BadLogin", "Этот логин уже занят, попробуйте другой");

            }
            else ModelState.AddModelError("BadModel", "Некорректные логин и(или) пароль");

            return View(model);
        }
        private async Task Authenticate(string login)
        {
            //признаки авторизции 
            var Claims = new List<Claim>
            {
               new Claim(ClaimsIdentity.DefaultNameClaimType, login)
            };

            //параметр для передачи в запрос для аутентификации по кукам
            //~~формирует куку конкретного юзера зашифровывает, чтобы потом расшифровать 
            //и определить что это тот самый юзер в new Claim(ClaimsIdentity.DefaultNameClaimType, login)
            ClaimsIdentity id = new ClaimsIdentity(Claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            //устанавливаем куки авторизованного юзера
            //схема установлена в классе стартап 
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));

        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
