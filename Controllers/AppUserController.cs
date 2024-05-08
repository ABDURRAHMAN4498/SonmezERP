using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SonmezERP.Data;
using SonmezERP.Dtos;
using SonmezERP.Models;
using SonmezERP.ViewModels;

namespace SonmezERP.Controllers
{
    public class AppUserController : Controller
    {
        private readonly UserManager<AppUser> _UserManager;

        public AppUserController(UserManager<AppUser> userManager)
        {
            _UserManager = userManager;
        }



        // GET: AppUserController
        public async Task<ActionResult> Index()
        {
            var users = await _UserManager.Users.ToListAsync();
            
            return View(users);
        }

        // GET: AppUserController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            //var user = await _UserManager.Users.FirstOrDefault(x=>x.Id==id);

            return View();
        }

        // GET: AppUserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppUserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateUserDto createUserDto)
        {

            bool name = createUserDto.Name != string.Empty;
            bool userName = createUserDto.UserName != string.Empty;
            bool password = createUserDto.Password != string.Empty;

            AppUser appUser = new AppUser()
            {
                Name = createUserDto.Name,
                Surname = createUserDto.Surname,
                UserName = createUserDto.UserName

            };
            var result = await _UserManager.CreateAsync(appUser, createUserDto.Password);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(appUser);
        }

        // GET: AppUserController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var user = await _UserManager.FindByIdAsync(id.ToString());

            return View(user);
        }

        // POST: AppUserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditUserViewModel editUserViewModel)
        {
            var user = await _UserManager.FindByIdAsync(editUserViewModel.Id.ToString());

            var result = await _UserManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();

        }

        // GET: AppUserController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var user = await _UserManager.FindByIdAsync(id.ToString());
            return View(user);
        }

        // POST: AppUserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Delete(int id, EditUserViewModel editUserViewModel)
        {
            var user = await _UserManager.FindByIdAsync(id.ToString());
            var result =await _UserManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
        private bool AppUserExists(int id)
        {
            //return _UserManager.Users.Any(e => e.Id == id);
            return true;
        }
    }
}
