using Hotel.Models;
using Hotel.Models.Constants;
using Hotel.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Log")] AccountViewModel acc)
        {
            var model = acc.Log;

            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Credentials");
                return View();
            }

            var signinResult = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);

            if (!signinResult.Succeeded)
            {
                ModelState.AddModelError("", "Invalid Credentials");
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Reg")] AccountViewModel acc)
        {
            var model = acc.Reg;

            var dbUser = await _userManager.FindByNameAsync(model.Username);
            if (dbUser != null)
            {
                ModelState.AddModelError(nameof(acc.Reg.Username), "The user with this username already exists ");
                return View();
            }

            User user = new User
            {
                Name = model.Name,
                Surname = model.Surname,
                UserName = model.Username,
                Email = model.Email
            };

            var IdentityResult = await _userManager.CreateAsync(user, model.Password);
            if (!IdentityResult.Succeeded)
            {
                foreach (var item in IdentityResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }

            await _userManager.AddToRoleAsync(user, RoleConstants.User);

            await _signInManager.SignInAsync(user, true);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
