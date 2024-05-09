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
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName!, model.Password!, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                //ModelState.AddModelError("", "Invalid Login Attempt");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            bool password = registerVM.Password == registerVM.ConfirmPassword;
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    Name = registerVM.Name,
                    Surname = registerVM.Surname,
                    UserName = registerVM.UserName,
                };
                var result = await _userManager.CreateAsync(user,registerVM.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user,false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index));
        }
        
    }
}
