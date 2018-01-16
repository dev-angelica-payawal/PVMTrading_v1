﻿using System;
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

        [HttpPost]
        public ActionResult Save(Product product)
        {


            product.DateCreated = DateTime.Now;
            _context.Products.AddOrUpdate(product);
            //    _context.Products.Add(product);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ProductViewModel
            {
                Product = product,
                Brands = _context.Brands.ToList(),
                Branches = _context.Branches.ToList(),
                ProductConditions = _context.ProductConditions.ToList(),
                ProductCategories = _context.ProductCategories.ToList()

            };

            return View("New", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var product = _context.Products.Single(p => p.Id == id);
            if (product.Id != 0)
                _context.Products.Remove(product);


            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return Content("Not yet Available");
        }
    }
}