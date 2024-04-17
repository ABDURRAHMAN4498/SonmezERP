﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SonmezERP.Data;
using SonmezERP.Models;

namespace SonmezERP.Controllers
{
    public class ProductInputLogController : Controller
    {
        private readonly SonmezERPContext _context;

        public ProductInputLogController(SonmezERPContext context)
        {
            _context = context;
        }

        // GET: ProductInputLogController
        public async Task<ActionResult> Index()
        {

            var sonmezERPContext = _context.ProducInputLogs;
            return View(await sonmezERPContext.ToListAsync());
        }

        // GET: ProductInputLogController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductInputLogController/Create
        public ActionResult Create()
        {
            var ProductInputLog = new ProductInputLog();
            ProductInputLog.Inputs.Add(new ProductInputLogList() { Id=1});
            //ViewData["ProductsList"] = new SelectList(_context.Products.Include(p=>p.Color), "Id", "ProductAndColor");
            ViewData["ProductsList"] = new SelectList((from m in _context.Products.Include(p => p.Color)
                                                       select new
                                                       {
                                                           Id = m.Id,
                                                           PorductAndColor = m.ProductNameTr + " - " + m.Color.ColorName
                                                       }), "Id", "PorductAndColor");
            return View(ProductInputLog);
        }

        // POST: ProductInputLogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(
            //IFormCollection collection
            [FromForm] ProductInputLog prdLog
            )
        {
            foreach (var item in prdLog.Inputs)
            {
                if (item.ProductId!=null&&item.InputQuantity!=null)
                {
                    Product? product = await _context.Products.FindAsync(item.ProductId);
                    product.Stock += item.InputQuantity;
                    _context.Products.Update(product);
                    item.ProductInputId = prdLog.Id;
                    item.dateTime = DateTime.Now;
                    _context.ProductInputLogList.AddAsync(item);
                }
            }
            _context.ProducInputLogs.AddAsync(prdLog);
            await _context.SaveChangesAsync();

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductInputLogController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductInputLogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: ProductInputLogController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductInputLogController/Delete/5
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
    }
}
