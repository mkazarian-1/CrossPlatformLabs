using Lab6.Data;
using Lab6.Dto;
using Lab6.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<List<CustomerDto>>> GetCustomers([FromQuery] string? name, [FromQuery] DateTime? date)
        {
            var query = _context.Customers.AsQueryable();
            
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(c => c.CustomerName!.Contains(name));
            }

            if (date.HasValue)
            {
                query = query.Where(c => c.DateBecameCustomer.Date == date.Value.Date);
            }
            
            var customers = await query
                .Select(c => new CustomerDto
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    CustomerPhone = c.CustomerPhone,
                    CustomerEmail = c.CustomerEmail,
                    DateBecameCustomer = c.DateBecameCustomer
                })
                .ToListAsync();

            return Ok(customers);
        }

        // GET: api/Customer/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers
                .Include(c => c.RefPaymentMethod) 
                .Include(c => c.CustomerAddresses) 
                .ThenInclude(ca => ca.Address) 
                .Include(c => c.RegularOrders) 
                .FirstOrDefaultAsync(c => c.CustomerId == id);

            if (customer == null)
            {
                return NotFound();
            }
            
            return Ok(customer);
        }
    }
}