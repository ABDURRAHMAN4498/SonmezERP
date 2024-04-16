using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

            return View(ProductInputLog);
        }

        // POST: ProductInputLogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            //IFormCollection collection
            [FromForm] ProductInputLog prdLog
            )
        {
            foreach (var item in prdLog.Inputs)
            {
                var 
                _context.ProductInputLogList.Add(item);
            }
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
