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
    public class ProductsController : Controller
    {
        private readonly SonmezERPContext _context;

        public ProductsController(SonmezERPContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewBag.Brands = _context.Brands.ToListAsync();
            ViewBag.Categoreis = _context.Categoreis.ToListAsync();
            ViewBag.Kdv = _context.Kdv.ToListAsync();
            ViewBag.Color = _context.Colors.ToListAsync();
            ViewBag.Uom = _context.UnitsOfMeasurements.ToListAsync();
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Product product)
        {
            if (!ModelState.IsValid)
            {
                var prdDtls = new ProductDetails()
                {
                    ProductWidth = product.ProductDetails.ProductWidth,
                    ProductHight = product.ProductDetails.ProductHight,
                    ProductSize = product.ProductDetails.ProductSize,
                    ProductWeight = product.ProductDetails.ProductWeight,
                    PackageWidth = product.ProductDetails.PackageWidth,
                    PackageSize = product.ProductDetails.PackageSize,
                    PackageHight = product.ProductDetails.PackageHight,
                    PackagePices = product.ProductDetails.PackagePices,
                    CubicMeter = product.ProductDetails.CubicMeter,
                    Tir = product.ProductDetails.Tir,
                    Container = product.ProductDetails.Container,
                    Coordinate = product.ProductDetails.Coordinate,
                    Descreption = product.ProductDetails.Descreption

                };
                
                _context.ProductDetails.Add(prdDtls);
                var prd = new Product()
                {
                    Visiblity = product.Visiblity,
                    ProductCode = product.ProductCode,
                    Barcode = product.Barcode,
                    BrandId = product.Brand.Id,
                    CategoryId = product.CategoryId,
                    ProductNameTr = product.ProductNameTr,
                    ProductNameEn = product.ProductNameEn,
                    ColorId = product.Color.Id,
                    PriceTl = product.PriceTl,
                    PriceUSD = product.PriceUSD,
                    KdvId = product.Kdv.Id,
                    UnitsOfMeasurementId = product.UnitsOfMeasurementName.Id,
                    ProductDetailsId = product.ProductDetails.Id,
                    CeateDate = DateTime.Now
                };
                _context.Products.Add(prd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
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
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Visiblity,ProductCode,Barcode,ProductNameTr,ProductNameEn,PriceTl,PriceUSD,CeateDate")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
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
