using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PVMTrading_v1.Models;
using PVMTrading_v1.ViewModels;

namespace PVMTrading_v1.Controllers
{
    public class SearchProductController : Controller
    {
        private ApplicationDbContext _context;

        public SearchProductController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: SearchProduct
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult SearchProduct()
        {
            /*var product = _context.Products.SingleOrDefault(p => p.Id == id);
            var productInclsion = _context.ProductInclusions.SingleOrDefault(p => p.ProductId == id);
            var productPrices = _context.ProductPrices.OrderByDescending(p => p.DateCreated).FirstOrDefault();
            
            if (product == null)
            {
                return HttpNotFound();
            }
            */
            /* Need to get dynamically all prices base to its product id and get only their newest price*/


            /*
                        var productPrices = _context.Products.Join(_context.ProductPrices, c => c.Id, p => p.ProductId,
                            (product, productPrice) => new
                            {
                                Product = product,
                                ProductPrice = productPrice
                            }).OrderByDescending( p=> p.ProductPrice.DateCreated).FirstOrDefault();



                        var prodPrice = _context.Products.ToList();
                        foreach (var item in productPrices)
                        {
                            item.ProductP.Person = (from p in db.People
                                where p.BusinessEntityID == item.PersonID
                                select p).First();
                        }
                        return View(departments.ToList());

                        /* var prices = _context.ProductPrices.Join(_context.Products, c => c.ProductId, p => p.Id,
                             (productPrice, product) => new
                             {

                             });
             #1#
                        var countProducts =;
                       */

            //  _context.ProductPrices.SqlQuery("Select * From ProductPrices,Products Where Products.Id = ProductPrices.ProductId");
            var productPrices = _context.Products.Join(_context.ProductPrices, c => c.Id, p => p.ProductId,
                (product, productPrice) => new
                {
                    Product = product,
                    ProductPrice = productPrice
                }).OrderByDescending(p => p.ProductPrice.DateCreated).FirstOrDefault();

            var price = _context.Products.Join(_context.ProductPrices, product => product.Id, p => p.ProductId,
                (p, pp) => new
                {
                    Product = p,
                    ProductPrice = pp}).ToList();

            var priceList = price.OrderByDescending(p => p.ProductPrice.DateCreated).FirstOrDefault();
            
            ViewBag.productCounts = _context.Products.Count();


            return View(priceList);
        }
    }
}