using CustomerAdminPortal.Data;
using CustomerAdminPortal.Models;
using CustomerAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAdminPortal.Controllers
{
    // localhost:xxxx/api/customers
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext dbcontext;

        public CustomersController(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            return Ok(dbcontext.Customers.ToList());
        }
        [HttpGet]
        [Route("id:guid")]
        public IActionResult GetCustomerById(Guid id)
        {
            var customer = dbcontext.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost] 
        public IActionResult AddCustomer(AddCustomerDto addCustomerDto)
        {
            var customerEntity = new Customer()
            {
                Name = addCustomerDto.Name,
                Email = addCustomerDto.Email,
                Phone = addCustomerDto.Phone,
                Address = addCustomerDto.Address,
                City = addCustomerDto.City,

            };
            dbcontext.Customers.Add(customerEntity);    
            dbcontext.SaveChanges();
            return Ok(customerEntity);
        }
        [HttpPut]
        [Route("id:guid")]
        public IActionResult UpdateCustomer(Guid id, UpdateCustomerDto updateCustomerDto)
        {
             var customer = dbcontext.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            customer.Name = updateCustomerDto.Name;
            customer.Email = updateCustomerDto.Email;   
            customer.Phone = updateCustomerDto.Phone;   
            customer.Address = updateCustomerDto.Address;   
            customer.City = updateCustomerDto.City; 

            dbcontext.SaveChanges();    
            return Ok("Customer Updated successfully");    

        }
        [HttpDelete]
        [Route("id:guid")]
        public IActionResult DeleteCustomer(Guid id)
        {
            var customer =dbcontext.Customers.Find(id);
            if (customer is null)
            {
                return NotFound();

            }
            dbcontext.Customers.Remove(customer);
            dbcontext.SaveChanges();
            return Ok(" Customer Deleted Successfully");    
        }
    }
}