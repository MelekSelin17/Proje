using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Controllers
{
    public class UserController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;

        public UserController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
          
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserModel createUserModel)
        {
            var newUser = new IdentityUser()
            {
                UserName = createUserModel.UserName,
                 Email = createUserModel.Email,
            };
            await _userManager.CreateAsync(newUser, createUserModel.Password);
            return View();
        }
    }
}
