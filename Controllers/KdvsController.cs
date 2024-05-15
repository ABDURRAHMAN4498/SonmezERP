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
    [Authorize]
    public class KdvsController : Controller
    {
        private readonly SonmezERPContext _context;

        public KdvsController(SonmezERPContext context)
        {
            _context = context;
        }

        // GET: Kdvs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kdv.ToListAsync());
        }

        // GET: Kdvs/Details/5
        public async Task<IActionResult> Details(int id)
        {
           var kdv = await _context.Kdv
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kdv == null)
            {
                return NotFound();
            }

            return View(kdv);
        }

        // GET: Kdvs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kdvs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KdvName")] Kdv kdv)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(kdv);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kdv);
        }

        // GET: Kdvs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kdv = await _context.Kdv.FindAsync(id);
            if (kdv == null)
            {
                return NotFound();
            }
            return View(kdv);
        }

        // POST: Kdvs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KdvName")] Kdv kdv)
        {
            if (id != kdv.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kdv);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KdvExists(kdv.Id))
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
            return View(kdv);
        }

        // GET: Kdvs/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            

            var kdv = await _context.Kdv
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kdv == null)
            {
                return NotFound();
            }

            return View(kdv);
        }

        // POST: Kdvs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kdv = await _context.Kdv.FindAsync(id);
            if (kdv != null)
            {
                _context.Kdv.Remove(kdv);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KdvExists(int id)
        {
            return _context.Kdv.Any(e => e.Id == id);
        }
    }
}
