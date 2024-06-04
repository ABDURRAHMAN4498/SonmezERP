using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SonmezERP.Data;
using SonmezERP.Models;

namespace SonmezERP.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SonmezERPContext _context;

        public RoleController(
            RoleManager<AppRole> roleManager
            , SonmezERPContext context
            )
        {
            _context = context;
            _roleManager = roleManager;
        }
        [Authorize(Roles = "Roles,Admin")]
        public async Task<IActionResult> Index()
        {
            var Roles = await _roleManager.Roles.OrderBy(item => item.Name).ToListAsync();

            return View(Roles);
        }
        [Authorize(Roles = "Roles_Create,Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Roles_Create,Admin")]

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

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var role = _context.Roles.Find(id);
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] AppRole appRole)
        {
            var role = await _roleManager.FindByIdAsync(appRole.Id);
            role!.Name = appRole.Name!;
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index"); // Rol güncellendikten sonra yönlendirilecek sayfa
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(appRole);

            #region 
            // appRole.NormalizedName = appRole.Name!.ToUpper();

            // if (ModelState.IsValid)
            // {
            //     _context.Entry(appRole).State = EntityState.Modified;
            //     _context.SaveChanges();
            //     return RedirectToAction("Index");
            // }
            // return View(appRole);
            #endregion
        }
    }
}
