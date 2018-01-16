using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PVMTrading_v1.Models;
using PVMTrading_v1.ViewModels;

namespace PVMTrading_v1.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _context;

        public ProductController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Product
        public ViewResult Index()
        {

            var products = _context.Products.Include(c => c.Brand)
                                            .Include(q => q.Branch)
                                            .Include(w => w.ProductCategory)
                                            .Include(e => e.ProductCondition).ToList();

            return View(products);

        }

        public ActionResult New()
        {
            var brands = _context.Brands.ToList();
            var branches = _context.Branches.ToList();
            var productCategories = _context.ProductCategories.ToList();
            var productConditions = _context.ProductConditions.ToList();

            var viewModels = new ProductViewModel
            {
                Brands = brands,
                Branches = branches,
                ProductCategories = productCategories,
                ProductConditions = productConditions

            };
            return View(viewModels);
        }


        public ActionResult Save(Product product)
        {


            product.DateCreated = DateTime.Now;
            _context.Products.AddOrUpdate(product);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}