using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SonmezERP.Data;
using SonmezERP.Models;
using SonmezERP.ViewModels;

namespace SonmezERP.Controllers
{
    public class AppUserController : Controller
    {
        private readonly SonmezERPContext _context;

        public AppUserController(SonmezERPContext context)
        {
            _context = context;
        }

        // GET: AppUserController
        public async Task<ActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: AppUserController/Details/5
        public ActionResult Details(int id)
        {
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
        public async Task<ActionResult> Create(AppUser appUser)
        {
            bool name = appUser.Name != string.Empty;
            bool userName = appUser.UserName != string.Empty;
            bool password = appUser.PasswordHash != string.Empty;


            if (name&&userName&&password)
            {
                 _context.Users.Add(appUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                
            }
            return View(appUser);
        }

        // GET: AppUserController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id<=0)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);

            return View(user);
        }

        // POST: AppUserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditUserViewModel editUserViewModel)
        {
            var user =await _context.Users.FindAsync(editUserViewModel.Id);

            try
            {
                _context.Update(editUserViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (AppUserExists(editUserViewModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return View();

        }

        // GET: AppUserController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user==null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: AppUserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private bool AppUserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
