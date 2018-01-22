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
        public ActionResult Save(Product product, ProductInclusion productInclusion)
        {
            /* if (!ModelState.IsValid)
             {
                 var viewModel = new ProductViewModel
                 {
                     Product = product,
                     Brands = _context.Brands.ToList(),
                     Branches = _context.Branches.ToList(),
                     ProductCategories = _context.ProductCategories.ToList(),
                     ProductConditions = _context.ProductConditions.ToList(),
                 };

                 return View("New", viewModel);
             }*/

            if (product.Id == 0)
            {
                productInclusion.ProductId = product.Id;
                _context.ProductInclusions.Add(productInclusion);
                product.DateCreated = DateTime.Now;
                _context.Products.Add(product);
            }
            else
            {
                var productInDb = _context.Products.Single(p => p.Id == product.Id);
                productInDb.Name = product.Name;
                productInDb.Description = product.Description;
                productInDb.Barcode = product.Barcode;
                productInDb.BranchId = product.BranchId;
                productInDb.BrandId = product.BrandId;
                productInDb.ProductCategoryId = product.ProductCategoryId;
                productInDb.IsReturned = product.IsReturned;
                productInDb.Model = product.Model;
                productInDb.OriginalPrice = product.OriginalPrice;
                productInDb.ProductConditionId = product.ProductConditionId;
                productInDb.SerialNumber = product.SerialNumber;
                productInDb.Quantity = product.Quantity;

                var productInclusionInDb = _context.ProductInclusions.Single(p => p.ProductId == product.Id);
                productInclusionInDb.FreeItem = productInclusion.FreeItem;
                productInclusion.Quantity = productInclusion.Quantity;
            }



            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);

            var productInclsion = _context.ProductInclusions.SingleOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ProductViewModel
            {
                Product = product,
                ProductInclusion = productInclsion,
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
            var productInclusion = _context.ProductInclusions.Single(p => p.ProductId == id);
            if (product.Id != 0)
            {
                _context.ProductInclusions.Remove(productInclusion);
                _context.Products.Remove(product);
            }


            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return Content("Not yet Available");
        }
    }
}