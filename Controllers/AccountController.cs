using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Proje.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Login(string errorMessage)
        {
             
            ViewBag.ErrorMessage = errorMessage;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username,string password)
        
       {
            //HttpClientHandler handler = new HttpClientHandler
            //{
            //    Credentials = new
            //System.Net.NetworkCredential("my_client_id", "my_client_secret")
            //};
            //HttpClient httpClient = new HttpClient(handler);

            var result = await _signInManager.PasswordSignInAsync(username, password,false,false);
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");
            return RedirectToAction("login", "Account", new { errorMessage = "Giriş hatalı" });

        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
