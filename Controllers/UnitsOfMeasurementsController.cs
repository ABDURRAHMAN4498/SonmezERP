using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SonmezERP.Data;
using SonmezERP.Models;

namespace SonmezERP.Controllers
{
    public class UnitsOfMeasurementsController : Controller
    {
        private readonly SonmezERPContext _context;

        public UnitsOfMeasurementsController(SonmezERPContext context)
        {
            _context = context;
        }

        // GET: UnitsOfMeasurements
        public async Task<IActionResult> Index()
        {
            return View(await _context.UnitsOfMeasurements.ToListAsync());
        }

        // GET: UnitsOfMeasurements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitsOfMeasurement = await _context.UnitsOfMeasurements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unitsOfMeasurement == null)
            {
                return NotFound();
            }

            return View(unitsOfMeasurement);
        }

        // GET: UnitsOfMeasurements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnitsOfMeasurements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UnitsOfMeasurementName")] UnitsOfMeasurement unitsOfMeasurement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unitsOfMeasurement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unitsOfMeasurement);
        }

        // GET: UnitsOfMeasurements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitsOfMeasurement = await _context.UnitsOfMeasurements.FindAsync(id);
            if (unitsOfMeasurement == null)
            {
                return NotFound();
            }
            return View(unitsOfMeasurement);
        }

        // POST: UnitsOfMeasurements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UnitsOfMeasurementName")] UnitsOfMeasurement unitsOfMeasurement)
        {
            if (id != unitsOfMeasurement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unitsOfMeasurement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitsOfMeasurementExists(unitsOfMeasurement.Id))
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
            return View(unitsOfMeasurement);
        }

        // GET: UnitsOfMeasurements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitsOfMeasurement = await _context.UnitsOfMeasurements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unitsOfMeasurement == null)
            {
                return NotFound();
            }

            return View(unitsOfMeasurement);
        }

        // POST: UnitsOfMeasurements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unitsOfMeasurement = await _context.UnitsOfMeasurements.FindAsync(id);
            if (unitsOfMeasurement != null)
            {
                _context.UnitsOfMeasurements.Remove(unitsOfMeasurement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnitsOfMeasurementExists(int id)
        {
            return _context.UnitsOfMeasurements.Any(e => e.Id == id);
        }
    }
}
