using System;
using System.Collections.Generic;
using System.Data;
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
            var cashtransact = _context.CashTransactions.Include(c => c.Customer).ToList();
            
            return View(cashtransact);
        }

        //select customer search
        public ActionResult SearchCustomer()
        {
            var customers = _context.Customers;

            var customersList = customers.ToList();
            return View(customersList);
        }

      
        
        public ActionResult CashTransactionSummary(/*string cashId*/)
        {
            var count = _context.CashTransactions.Count();
            var cashId = Convert.ToString(DateTime.Today.Year) + "0" + Convert.ToString(count) + "00" + Convert.ToString(DateTime.Today.Day);

            var currentTransaction = _context.CashTransactions.SingleOrDefault(c => c.Id == cashId);

            var viewModel = new CashTransactionViewModel
            {   CashTransaction = currentTransaction,
              /* CashTransactionItem =_context.CashTransactionItems.Where(c => c.CashTransactionId == cashId).ToList(), 
              */  Customer = _context.Customers.ToList()
            };

            
              
            return View(viewModel);
        }


        public ActionResult CashTransactionSummaryItemList()
        {
            var count = _context.CashTransactions.Count();
            var cashId = Convert.ToString(DateTime.Today.Year) + "0" + Convert.ToString(count) + "00" + Convert.ToString(DateTime.Today.Day);
            var productList = _context.CashTransactionItems.Where(c => c.CashTransactionId == cashId).ToList();

            return View(productList);
        }

        //Save CashTransaction
        public ActionResult Select(int id)
        {
            var cashTransaction = new CashTransaction();
            var cashTransactionItems = new CashTransactionItem();
            double totalPrice = 0;
            var temps = _context.TempCarts.ToList();
            foreach (var c in temps)
            {
        
                ViewData["products"] = c;
                totalPrice = totalPrice + (c.ProductPrice * c.Quantity);
            }

            var count = _context.CashTransactions.Count();
            var cashId = Convert.ToString(DateTime.Today.Year)+ "0" + Convert.ToString(count + 1)+"00" + Convert.ToString(DateTime.Today.Day);
            var selectCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var cashTransacItem = new CashTransactionItem();
            if (selectCustomer.Id != 0) {

                foreach (var g in temps)
                {
                    cashTransacItem.CashTransactionId = cashId;
                    cashTransacItem.ProductId = g.ProductId;
                    cashTransacItem.Quantity = g.Quantity;
                    cashTransacItem.ProductPrice=g.ProductPrice;
                    _context.CashTransactionItems.Add(cashTransacItem);
                    
                }
                
              cashTransaction.Id = cashId;
            cashTransaction.CustomerId = selectCustomer.Id;
            cashTransaction.OriginalTotalAmount = totalPrice;
            cashTransaction.TotalDiscountedAmount = 0;
            cashTransaction.TotalAmount = cashTransaction.OriginalTotalAmount-cashTransaction.TotalDiscountedAmount;
            cashTransaction.Remarks = "";
                cashTransaction.OR = 0;
              


            _context.CashTransactions.Add(cashTransaction);
            }
            _context.SaveChanges();
            return RedirectToAction("CashTransactionSummary"/*, cashId*/);

        }

        /*public JsonResult AutocompleteSuggestions(string searchstring)
        {
            
        var suggestions = from s in _context.Customers
            select s.FirstName;
            var suggest = _context.Customers.ToList();
        var namelist = suggestions.Where(n => n.ToLower().StartsWith(searchstring.ToLower()));

            return Json(namelist, JsonRequestBehavior.AllowGet);
    }*/

    /*  public ActionResult Grid()
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
*/
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



    /*  public ActionResult ProductInfo(int id)
      {

          var product = _context.Products.SingleOrDefault(c => c.Id == id);
          /*if (product == null)
          {
              return HttpNotFound();
          }
          var productInfo = new ProductViewModel()
          {
              Product = product

          };


          return PartialView(productInfo);#1#

          /*var order = (Product)Session["Order"];
          return PartialView(order.Model);#1#

          return View(product);
      }*/

    /*       public ActionResult ProductView()
           {
               var product = _context.Products.ToList();

               if (product == null)
               {
                   return HttpNotFound();
               }
               var Productsview = new CashTransactionViewModel()
               {
                   Product = product,
                   CustomerCompleInfo = customerInfo,
                   CustomerTypes = _context.CustomerTypes.ToList(),
                   CivilStatuses = _context.CivilStatus.ToList()
               };


               return PartialView(Productsview);

           }*/




}
}