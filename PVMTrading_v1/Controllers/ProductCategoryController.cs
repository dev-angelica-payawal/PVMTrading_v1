using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PVMTrading_v1.Models;

namespace PVMTrading_v1.Controllers
{
    public class ProductCategoryController : Controller
    {
        private ApplicationDbContext _context;

        public ProductCategoryController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: ProductCategory
        public ActionResult Index()
        {
            var productCategory = _context.ProductCategories.ToList();
            return View(productCategory);
        }
    }
}