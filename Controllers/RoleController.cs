using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SonmezERP.Models;

namespace SonmezERP.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        [Authorize(Roles ="Roles,Admin")]
        public async Task<IActionResult> Index()
        {
            var Roles = await _roleManager.Roles.OrderBy(item => item.Name).ToListAsync();
            
            return View(Roles);
        }
        [Authorize(Roles ="Roles_Create,Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles ="Roles_Create,Admin")]

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] AppRole appRole)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(appRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception("Yetki Oluşturulamadı!");
                }
            }
            return View(appRole);
        }
    }
}
