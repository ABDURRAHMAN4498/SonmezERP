using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SonmezERP.Dtos;
using SonmezERP.Models;
using SonmezERP.ViewModels;

namespace SonmezERP.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _userManager.Users.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(
                new UserDtoForCreation()
                {
                    Roles = new HashSet<string>(_roleManager.Roles.Select(r => r.Name).ToList()!)
                }
                );
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserDtoForCreation userDto)
        {
            var user = new AppUser()
            {
                Name=userDto.Name,
                Surname = userDto.Surname,
                UserName = userDto.UserName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
            };
            var result = await _userManager.CreateAsync(user,userDto.Password!);
            if (!result.Succeeded)
            {
                throw new Exception("Kullanıcı Oluşturulamadı.");
            }
            if (userDto.Roles.Count>0)
            {
                var roleResult = await _userManager.AddToRolesAsync(user, userDto.Roles);
                if (!roleResult.Succeeded)
                {
                    throw new Exception("Sistemin Rollerle İlgili sorunları var!!");
                }
            }
            return result.Succeeded
                ? RedirectToAction("Index")
                : View();
        }

    }
}
