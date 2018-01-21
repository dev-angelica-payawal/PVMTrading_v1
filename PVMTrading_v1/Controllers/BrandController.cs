﻿using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
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
            var brand = _context.Brands.SingleOrDefault(p => p.Id == id);

            if (brand == null)
            {
                return HttpNotFound();
            }

            var viewModel = new BrandViewModel
            {
                Brand = brand,
                BrandTypes = _context.BrandTypes.ToList(),
            };

            return View("New", viewModel);
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



            if (brand.Id == 0)
            {

                _context.Brands.Add(brand);
            }
            else
            {
                var brandInDb = _context.Brands.Single(p => p.Id == brand.Id);
                brandInDb.BrandName = brand.BrandName;
                brandInDb.BrandTypeId = brand.BrandTypeId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var brand = _context.Brands.Single(p => p.Id == id);
            if (brand.Id != 0)
                _context.Brands.Remove(brand);


            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return Content("Not yet Available");
        }
    }
}