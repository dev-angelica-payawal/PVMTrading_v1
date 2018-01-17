using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PVMTrading_v1.Models;

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
    }
}