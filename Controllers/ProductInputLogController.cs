using Microsoft.AspNetCore.Http;
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
            
            var sonmezERPContext = _context.ProductInputLogList.Include(p=>p.Product).Include(p=>p.Product.Color).Include(p=>p.Product.UnitsOfMeasurement).Take(1500);
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
            ProductInputLog.Inputs.Add(new ProductInputLogList() { dateTime=DateTime.Now});
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
            [FromForm] ProductInputLog productInput
            )
        {
            
                foreach (var item in productInput.Inputs)
                {
                    if (item.ProductId !=null && item.ProductId>0 && item.InputQuantity != null)
                    {
                        Product? product = await _context.Products.FindAsync(item.ProductId);
                        product.Stock =product.Stock+ item.InputQuantity;
                        _context.Products.Update(product);
                        item.dateTime = DateTime.Now;
                        _context.ProductInputLogList.AddAsync(item);
                    }
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
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
        public async Task<ActionResult> Delete(int id)
        {
            if (id<=0)
            {
                return NotFound();
            }
            var ProductLog = await _context.ProductInputLogList.Include(p=>p.Product).FirstOrDefaultAsync(p=>p.Id==id);
            var product = await _context.Products.Include(p => p.Color).FirstOrDefaultAsync(p => p.Id == ProductLog.ProductId);
            ProductLog.Product.Color.ColorName = product.Color.ColorName;
            return View(ProductLog);
        }

        // POST: ProductInputLogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id,[FromForm] ProductInputLogList productInputLogList)
        {
            if (id <=0 && productInputLogList.Id<=0)
            {
                return NotFound();
            }

            var productLog = await _context.ProductInputLogList
                .Include(p=>p.Product)
                .FirstOrDefaultAsync(p=>p.Id == productInputLogList.Id);
            if (productLog==null)
            {
                return Problem("Silmek istetdiğiniz kaydı bulamadı");
            }
            var product = await _context.Products                
                .FindAsync(productLog.ProductId);
           
            if (productInputLogList.InputQuantity>0)
            {
                product.Stock-=productInputLogList.InputQuantity;
                _context.Remove(productLog);
                _context.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(productLog);
            
        }
    }
}
