using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // Accessing the database requires a DBContext.
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        // We also need to close the DBContext after we are done with database.
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            //// Get the DBSet of Customer. We also need the DBSet of MembershipType as well, so use the Include().
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View();
        }

        // GET: Customer/Details/{id}
        public ActionResult Details(int id)
        {
            // Query the DBSet of Customer for the data.
            var customerWithMemberShip = _context.Customers.Include(c => c.MembershipType);
            var customer = customerWithMemberShip.SingleOrDefault(c => c.ID == id);
            if (customer == null) return HttpNotFound();
            else return View(customer);
        }

        // GET: Customer/New
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        // GET: Customer/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerFormViewModel data)
        {
            //Check whether the Model is in a valid state
            if (!ModelState.IsValid)
            {
                data.MembershipTypes = _context.MembershipTypes.ToList();
                return View("CustomerForm", data);
            }

            // new customer
            if (data.Customer.ID == 0)
            {
                _context.Customers.Add(data.Customer);
            }
            // existing customer
            else
            {
                var customer = _context.Customers.Single(c => c.ID == data.Customer.ID);
                customer.Name = data.Customer.Name;
                customer.MembershipTypeID = data.Customer.MembershipTypeID;
                customer.BirthDate = data.Customer.BirthDate;
                customer.IsSubscribed = data.Customer.IsSubscribed;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        // GET: Customer/Edit/{id}
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.ID == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}