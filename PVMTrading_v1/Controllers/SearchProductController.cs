using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
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

	 
		public ActionResult SearchProd()
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
		/*   var productPrices= _context.Products.Join(_context.ProductPrices, c => c.Id, p => p.ProductId,
				(product, productPrice) => new SearchProductViewModels()
				{
					Product = product,
					ProductPrice = productPrice
				}).ToList();

			var ss = _context.ProductPrices.Include(s => s.Product).ToList();
		*/    /*  var price = _context.Products.Join(_context.ProductPrices, product => product.Id, p => p.ProductId,
				  (p, pp) => new
				  {
					  Product = p,
					  ProductPrice = pp}).ToList();

			  var priceList = price.OrderByDescending(p => p.ProductPrice.DateCreated).FirstOrDefault();

		  */

			
		  
			var prodList = _context.Database.SqlQuery<SearchProductViewModels>(@"SELECT Products.*, 
												 Amount = (Select top 1 ProductPrices.SellingPrice 
												From ProductPrices
												Where ProductPrices.ProductId = Products.Id
												Order by ProductPrices.Id Desc )
										FROM Products").ToList<SearchProductViewModels>();

			/*   var sample =_context.Database.SqlQuery<SearchProductViewModels>(@"Select Distinct Products.Name, Products.Model, Products.Id SellingPrice 
														   From Products Join  ProductPrices 
														   on Products.Id=ProductPrices.ProductId ");
			*/
			var prod = _context.ProductPrices.Include(p => p.Product).OrderByDescending(p => p.Id).DistinctBy(p => p.ProductId);
				ViewBag.productCounts = _context.Products.Count();

		
			return View(prod.ToList());


	  
		}
	}
}