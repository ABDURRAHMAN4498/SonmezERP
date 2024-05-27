using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SonmezERP.Data;
using SonmezERP.Models;

namespace SonmezERP.Controllers
{
    //
    public class DashboardSettingsController : Controller
    {
        private readonly SonmezERPContext _context;

        public DashboardSettingsController(SonmezERPContext context)
        {
            _context = context;
        }

        // GET: DashboardSettings
        [Authorize(Roles = "DashboardSettings,Admin")]
        public IActionResult Index()
        {
            List<DashboardSettings> Items = new();
            Items.AddRange(_context.DashboardSettingsItems);
            return View(Items);
        }
        [Authorize(Roles = "DashboardSettings_Details,Admin")]
        // GET: DashboardSettings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dashboardSettings = await _context.DashboardSettingsItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dashboardSettings == null)
            {
                return NotFound();
            }

            return View(dashboardSettings);
        }

        // GET: DashboardSettings/Create
        [Authorize(Roles = "DashboardSettings_Details,Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: DashboardSettings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "DashboardSettings_Create,Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DepartmentName,Description,ControllerName,ActionName,IconePath")] DashboardSettings dashboardSettings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dashboardSettings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dashboardSettings);
        }

        // GET: DashboardSettings/Edit/5
        [Authorize(Roles = "DashboardSettings_Edit,Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dashboardSettings = await _context.DashboardSettingsItems.FindAsync(id);
            if (dashboardSettings == null)
            {
                return NotFound();
            }
            return View(dashboardSettings);
        }

        // POST: DashboardSettings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "DashboardSettings_Edit,Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DepartmentName,Description,ControllerName,ActionName,IconePath")] DashboardSettings dashboardSettings)
        {
            if (id != dashboardSettings.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dashboardSettings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DashboardSettingsExists(dashboardSettings.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dashboardSettings);
        }
        [Authorize(Roles = "DashboardSettings_Delete,Admin")]
        // GET: DashboardSettings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dashboardSettings = await _context.DashboardSettingsItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dashboardSettings == null)
            {
                return NotFound();
            }

            return View(dashboardSettings);
        }

        // POST: DashboardSettings/Delete/5
        [Authorize(Roles = "DashboardSettings_Delete,Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dashboardSettings = await _context.DashboardSettingsItems.FindAsync(id);
            if (dashboardSettings != null)
            {
                _context.DashboardSettingsItems.Remove(dashboardSettings);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DashboardSettingsExists(int id)
        {
            return _context.DashboardSettingsItems.Any(e => e.Id == id);
        }
    }
}
