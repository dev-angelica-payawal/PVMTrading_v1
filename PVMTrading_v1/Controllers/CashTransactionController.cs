using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PVMTrading_v1.Models;
using PVMTrading_v1.ViewModels;

namespace PVMTrading_v1.Controllers
{
    public class CashTransactionController : Controller
    {

        private ApplicationDbContext _context;

        public CashTransactionController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: CashTransaction
        public ActionResult Index()
        {
            var customers = _context.Customers.ToList();

            var viewModels = new CashTransactionViewModel
            {
                Customer = customers
            };


            return View(viewModels);
        }

        //select customer search
        public ActionResult SearchCustomer()
        {
            throw new NotImplementedException();
        }

        public ActionResult SearchProduct()
        {
            throw new NotImplementedException();
        }

        public ActionResult Save()
        {
            throw new NotImplementedException();
        }
    }
}