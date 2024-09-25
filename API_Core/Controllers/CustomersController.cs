using Microsoft.Data.SqlClient;

namespace API_Core.Controllers
{
    using API_Core.Data;
    using API_Core.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetFilteredCustomers(
            string? customerName, string? customerCategory, string? deliveryMethod)
        {
            // Parámetros para el SP
            var customerNameParam = new SqlParameter("@CustomerName", customerName ?? (object)DBNull.Value);
            var customerCategoryParam = new SqlParameter("@CustomerCategoryName", customerCategory ?? (object)DBNull.Value);
            var deliveryMethodParam = new SqlParameter("@DeliveryMethodName", deliveryMethod ?? (object)DBNull.Value);

            // Llamada al SP GetFilteredCustomers
            var customers = await _context.Customers
                .FromSqlRaw("EXEC GetFilteredCustomers @CustomerName, @CustomerCategoryName, @DeliveryMethodName",
                            customerNameParam, customerCategoryParam, deliveryMethodParam)
                .ToListAsync();

            return Ok(customers);
        }

        // GET: api/customers/5
        [HttpGet("{id}")]
        public ActionResult<CustomerDetails> GetCustomerDetails(int id)
        {
            // Parámetros para el SP
            var customerIdParam = new SqlParameter("@CustomerID", id);

            // Llamada al SP GetCustomerDetails
            var customerDetails = _context.CustomerDetails
                .FromSqlRaw("EXEC GetCustomerDetails @CustomerID", customerIdParam)
                .AsEnumerable()  
                .FirstOrDefault(); 

            if (customerDetails == null)
            {
                return NotFound();
            }

            return Ok(customerDetails);
        }

    }
}
