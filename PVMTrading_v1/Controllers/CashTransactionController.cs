using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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
           


            return View();
        }

        //select customer search
        public ActionResult SearchCustomer()
        {
            var customers = _context.Customers.Include(c => c.Sex);

            var customersList = customers.ToList();

            return View(customersList);
        }

        public ActionResult Grid()
        {
            var result = (from c in _context.Customers
                select new Customer
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    MiddleName = c.MiddleName,
                    LastName = c.LastName
                }).ToList().AsQueryable(); ;
            return View(result);
        }

      /*  protected string RenderRazorViewToString(string viewName, object model)
        {
            if (model != null)
            {
                ViewData.Model = model;
            }

            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext,viewResult.View,ViewData,TempData,sw);
                viewResult.View.Render(viewContext,sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext,viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
            
        }*/

       

        public ActionResult Save()
        {
            throw new NotImplementedException();
        }
    }
}