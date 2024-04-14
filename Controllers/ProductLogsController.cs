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
    public class ProductLogsController : Controller
    {
        private readonly SonmezERPContext _context;

        public ProductLogsController(SonmezERPContext context)
        {
            _context = context;
        }

        // GET: ProductLogs
        public async Task<IActionResult> Index()
        {
            var sonmezERPContext = _context.ProductLogs.Include(p => p.Product).Include(p => p.Product.Color);
            return View(await sonmezERPContext.ToListAsync());
        }

        // GET: ProductLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productLog = await _context.ProductLogs
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productLog == null)
            {
                return NotFound();
            }

            return View(productLog);
        }

        // GET: ProductLogs/Create
        [HttpGet]
        public IActionResult Create()
        {
            //var product = _context.Products.Include(p => p.Color);
            ViewData["ProductId"] = new SelectList(_context.Products.Include(p => p.Color), "Id", "ProductAndColor");
            ViewBag.Products = new SelectList((from m in _context.Products.Include(p => p.Color)
                                               select new
                                               {
                                                   Id = m.Id,
                                                   ProductAndColor = m.ProductNameTr + " - " + m.Color.ColorName
                                               }), "Id", "ProductAndColor", null);
            return View();
        }

        // POST: ProductLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductLog productLog)
        {


            productLog.LogType = true;
            productLog.Output = 0;
            productLog.ActionDate = DateTime.Now;
            if (productLog.ProductId == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var product = await _context.Products.FindAsync(productLog.ProductId);
                product.Stock += Convert.ToInt32(productLog.Input);
                _context.Products.Update(product);
                _context.ProductLogs.Add(productLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Products = new SelectList((from m in _context.Products.Include(p => p.Color)
                                               select new
                                               {
                                                   Id = m.Id,
                                                   ProductAndColor = m.ProductNameTr + " - " + m.Color.ColorName
                                               }), "Id", "ProductAndColor", null);
            return View();
        }

        // GET: ProductLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productLog = await _context.ProductLogs.FindAsync(id);
            if (productLog == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productLog.ProductId);
            return View(productLog);
        }

        // POST: ProductLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,Input,Output,LogType,ActionDate")] ProductLog productLog)
        {
            if (id != productLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductLogExists(productLog.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productLog.ProductId);
            return View(productLog);
        }

        // GET: ProductLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productLog = await _context.ProductLogs
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productLog == null)
            {
                return NotFound();
            }

            return View(productLog);
        }

        // POST: ProductLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productLog = await _context.ProductLogs.FindAsync(id);
            if (productLog != null)
            {
                _context.ProductLogs.Remove(productLog);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductLogExists(int id)
        {
            return _context.ProductLogs.Any(e => e.Id == id);
        }
    }
}
