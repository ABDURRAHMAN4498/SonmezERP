using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SonmezERP.Models;
using SonmezERP.ViewModels;

namespace SonmezERP.Controllers
{

    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<AppUser> users = new List<AppUser>();
            users = await _userManager.Users.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginVM model)
        {
            if (ModelState.IsValid)
            {

                AppUser? user = await _userManager.FindByNameAsync(model.UserName!);
                if (user is not null)
                {
                    await _signInManager.SignOutAsync();
                    if ((await _signInManager.PasswordSignInAsync(user, model.Password!, false, false)).Succeeded)
                    {
                        return Redirect(model?.Returnurl ?? "/");
                    }
                }
                ModelState.AddModelError("Error", "Invalid username or password");
                //var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                //if (result.Succeeded)
                //{
                //    return RedirectToAction("Index", "Home");
                //}
                //ModelState.AddModelError("", "Invalid Login Attempt");
            }
            return View();
        }
        [Authorize]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            AppUser user = new AppUser()
            {
                Name = registerVM.Name,
                Surname = registerVM.Surname,
                UserName = registerVM.UserName,
            };
            bool password = registerVM.Password == registerVM.ConfirmPassword;
            if (ModelState.IsValid)
            {
                if (password)
                {
                    var result = await _userManager.CreateAsync(user, registerVM.Password!);
                    if (result.Succeeded)
                    {
                        var roleResult = await _userManager.AddToRoleAsync(user, "User");
                        if (roleResult.Succeeded)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                    }
                }
                else
                {
                    ModelState.AddModelError("Error","Şifreler eşleşmedi");
                }

            }
            return View(registerVM);
        }

        public async Task<IActionResult> Logout(/*[FromQuery(Name = "ReturnUrl")] string ReturnUrl="/"*/)
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        

    }
}
