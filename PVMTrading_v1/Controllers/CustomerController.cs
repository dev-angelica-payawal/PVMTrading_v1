using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PVMTrading_v1.Migrations;
using PVMTrading_v1.Models;
using PVMTrading_v1.ViewModels;

namespace PVMTrading_v1.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.CustomerType)
                                              .Include(p=> p.CivilStatus)
                                              .Include(s => s.Sex).ToList();


            return View(customers);
        }

        public ActionResult New()
        {
            var customersTypes = _context.CustomerTypes.ToList();
            var civilstatus = _context.CivilStatus.ToList();
            var sex = _context.Sex.ToList();

            var viewModels = new CustomerViewModel
            {
                CustomerTypes = customersTypes,
                CivilStatuses = civilstatus,
                Sexs = sex
            };
            

            return View(viewModels);

        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {

            if (customer.Id == 0)
            {
                customer.RegisteredDateCreated = DateTime.Now;
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.FirstName = customer.FirstName;
                customerInDb.MiddleName = customer.MiddleName;
                customerInDb.LastName = customer.LastName;
                customerInDb.NameExtension = customer.NameExtension;
                customerInDb.Mobile = customer.Mobile;
                customerInDb.Telephone = customer.Telephone;
                customerInDb.Email = customer.Email;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.CivilStatusId = customer.CivilStatusId;
                customerInDb.Sexid = customer.Sexid;
                customerInDb.PlaceOfBirth = customer.PlaceOfBirth;
                customerInDb.Nationality = customer.Nationality;
                customerInDb.TaxIdentificationNumber = customer.TaxIdentificationNumber;
                customerInDb.CivilStatusId = customer.CustomerTypeId;
                customerInDb.LotHouseNumberAndStreet = customer.LotHouseNumberAndStreet;
                customerInDb.Barangay = customer.Barangay;
                customerInDb.CityMunicipality= customer.CityMunicipality;
                customerInDb.Province = customer.Province;
                customerInDb.Country = customer.Country;
                customerInDb.ZipCode = customer.ZipCode;

            }


            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
                throw;
            }
                


            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            
            var viewModel = new CustomerViewModel
            { 

                Customer = customer,
 
                CustomerTypes =  _context.CustomerTypes.ToList(),
                CivilStatuses = _context.CivilStatus.ToList(),
                Sexs = _context.Sex.ToList()
            };

            return View("New", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.Single(c => c.Id == id);
            if (customer.Id != 0)
                _context.Customers.Remove(customer);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return Content("Not yet Available");
        }

    }
}