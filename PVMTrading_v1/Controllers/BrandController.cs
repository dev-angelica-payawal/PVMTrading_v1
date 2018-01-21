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
    public class BrandController : Controller
    {

        private ApplicationDbContext _context;

        public BrandController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Brand
        public ViewResult Index()
        {
            var brands = _context.Brands.Include(c => c.BrandType).ToList();

            return View(brands);
        }

        public ActionResult New()
        {
            var brandType = _context.BrandTypes.ToList();

            var viewModel = new BrandViewModel
            {
                BrandTypes = brandType
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BrandViewModel
                {
                    Brand = brand,
                    BrandTypes = _context.BrandTypes.ToList()
                };

                return View("New", viewModel);
            }
            _context.Brands.AddOrUpdate(brand);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}