﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SonmezERP.Data;
using SonmezERP.Models;

namespace SonmezERP.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly SonmezERPContext _context;

        public ProductsController(SonmezERPContext context)
        {
            _context = context;
        }
        [Authorize(Roles ="Products,Admin")]
        [HttpGet]
        // GET: Products
        public async Task<IActionResult> Index(int id=0)
        {
            
            //(_context.Brands, "Id", "BrandName");
            var sonmezERPContext = _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Color)
                .Include(p => p.Kdv)
                .Include(p => p.ProductDetails)
                .Include(p => p.UnitsOfMeasurement)
                .OrderBy(item => item.ProductNameTr);
            List<Brand> Brands = new List<Brand>();
            foreach (var item in  _context.Brands)
            {
                Brands.Add(item);
            }
            ViewData["Brands"] = Brands;
            if (id>0)
            {
                sonmezERPContext.Where(p => p.BrandId == id);
            }
           
            return View(await sonmezERPContext.ToListAsync());
        }

        // GET: Products/Details/5
        [Authorize(Roles ="Products_Details,Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Color)
                .Include(p => p.Kdv)
                .Include(p => p.ProductDetails)
                .Include(p => p.UnitsOfMeasurement)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        [Authorize(Roles ="Products_Create,Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "BrandName");
            ViewData["CategoryId"] = new SelectList(_context.Categoreis, "Id", "CategoryName");
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "ColorName");
            ViewData["KdvId"] = new SelectList(_context.Kdv, "Id", "KdvName");
            ViewData["ProductDetailsId"] = new SelectList(_context.ProductDetails, "Id", "ProductCode");
            ViewData["UnitsOfMeasurementId"] = new SelectList(_context.UnitsOfMeasurements, "Id", "UnitsOfMeasurementName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles ="Products_Create,Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm]
            //[Bind("Id,Visiblity,ProductCode,Barcode,BrandId,CategoryId,ProductNameTr,ProductNameEn,ColorId,PriceTl,PriceUSD,KdvId,UnitsOfMeasurementId,ProductDetailsId")]
        Product product)
        {
            if (ModelState.IsValid)
            {
                product.CeateDate  =DateTime.Now;
                product.ımagePath = "ABDSOFT";
                product.Stock = 0;
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categoreis, "Id", "Id", product.CategoryId);
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "ColorName", product.ColorId);
            ViewData["KdvId"] = new SelectList(_context.Kdv, "Id", "Id", product.KdvId);
            ViewData["ProductDetailsId"] = new SelectList(_context.ProductDetails, "Id", "ProductCode", product.ProductDetailsId);
            ViewData["UnitsOfMeasurementId"] = new SelectList(_context.UnitsOfMeasurements, "Id", "Id", product.UnitsOfMeasurementId);
            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles ="Products_Edit,Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "BrandName", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categoreis, "Id", "CategoryName", product.CategoryId);
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "ColorName", product.ColorId);
            ViewData["KdvId"] = new SelectList(_context.Kdv, "Id", "KdvName", product.KdvId);
            ViewData["ProductDetailsId"] = new SelectList(_context.ProductDetails, "Id", "ProductCode", product.ProductDetailsId);
            ViewData["UnitsOfMeasurementId"] = new SelectList(_context.UnitsOfMeasurements, "Id", "UnitsOfMeasurementName", product.UnitsOfMeasurementId);
            
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles ="Products_Edit,Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            //[Bind("Id,Visiblity,ProductCode,Barcode,BrandId,CategoryId,ProductNameTr,ProductNameEn,ColorId,PriceTl,PriceUSD,KdvId,UnitsOfMeasurementId,ProductDetailsId,CeateDate")]
        Product product)
        {
            Product? prd = _context.Products.Find(id);
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    product.ımagePath = "ABDSOFT";
                    product.Stock = prd!.Stock;
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categoreis, "Id", "Id", product.CategoryId);
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "ColorName", product.ColorId);
            ViewData["KdvId"] = new SelectList(_context.Kdv, "Id", "Id", product.KdvId);
            ViewData["ProductDetailsId"] = new SelectList(_context.ProductDetails, "Id", "Id", product.ProductDetailsId);
            ViewData["UnitsOfMeasurementId"] = new SelectList(_context.UnitsOfMeasurements, "Id", "Id", product.UnitsOfMeasurementId);
            return View(product);
        }
        // GET: Products/Delete/5
        [Authorize(Roles ="Products_Delete,Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Color)
                .Include(p => p.Kdv)
                .Include(p => p.ProductDetails)
                .Include(p => p.UnitsOfMeasurement)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [Authorize(Roles ="Products_Delete,Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
		}
        
        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
