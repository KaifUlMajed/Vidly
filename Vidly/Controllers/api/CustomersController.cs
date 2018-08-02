using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Models.DTOs;
using System.Data.Entity;

namespace Vidly.Controllers.api
{
    public class CustomersController : ApiController
    {
        ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: api/customers
        // We are working with the DTOs now. 
        public IHttpActionResult GetCustomers(string query = null)
        {
            // Map the Customer into its DTO.
            var allCustomers = _context.Customers.Include(c => c.MembershipType);
            if (!String.IsNullOrWhiteSpace(query))
            {
                allCustomers = allCustomers.Where(c => c.Name.Contains(query));
            }
            var customer = allCustomers.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
            return Ok(customer);
        }
        // GET: api/customers/id
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.Single(c => c.ID == id);
            if (customer == null) return NotFound();
            // Since customer is a single object, LINQ's SELECT wont work.
            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
        }
        // POST: api/customer
        // For this type of request, the properties of customer are in the request body which is the parameter of the method.
        // By convention, we return the newly created Customer object to the user.
        // API that creates a resource returns an 201 (Created) HTTP status code. So we use IHttpActionResult.
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            // Map the DTO into the Domain model object to store in database.
            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            // Add the ID of the Customer Object to the Customer DTO.
            customerDTO.ID = customer.ID;

            return Created(new Uri(Request.RequestUri + "/" + customerDTO.ID), customerDTO);
        }
        // PUT: api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            var customerInDB = _context.Customers.Single(c => c.ID == id);
            if (customerInDB == null) return NotFound();

            // Now map from the DTO into the Object retrieved from DB.
            Mapper.Map<CustomerDTO, Customer>(customerDTO, customerInDB);

            _context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
        // DELETE: api/customer/id
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            var customerInDB = _context.Customers.Single(c => c.ID == id);
            if (customerInDB == null) return NotFound();

            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
