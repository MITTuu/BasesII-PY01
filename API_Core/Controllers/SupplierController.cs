using Microsoft.AspNetCore.Mvc;

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
    public class SupplierController : Controller
    {
        private readonly AppDbContext _context;
        
        public SupplierController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/suppliers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetFilteredSuppliers(
            string? supplierName, string? supplierCategory, string? deliveryMethod)
        {
            // Parámetros para el SP
            var supplierNameParam = new SqlParameter("@SupplierName", supplierName ?? (object)DBNull.Value);
            var supplierCategoryParam = new SqlParameter("@SupplierCategoryName", supplierCategory ?? (object)DBNull.Value);
            var deliveryMethodParam = new SqlParameter("@DeliveryMethodName", deliveryMethod ?? (object)DBNull.Value);

            // Llamada al SP GetFilteredSuppliers
            var suppliers = await _context.Suppliers
                .FromSqlRaw("EXEC GetFilteredSuppliers @SupplierName, @SupplierCategoryName, @DeliveryMethodName",
                            supplierNameParam, supplierCategoryParam, deliveryMethodParam)
                .ToListAsync();

            return Ok(suppliers);
        }

        // GET: api/suppliers/5
        [HttpGet("{id}")]
        public ActionResult<SupplierDetails> GetSupplierDetails(int id)
        {
            // Parámetros para el SP
            var supplierIdParam = new SqlParameter("@SupplierID", id);

            // Llamada al SP GetSupplierDetails
            var supplierDetails = _context.SuppliersDetails
                .FromSqlRaw("EXEC GetSupplierDetails @SupplierID", supplierIdParam)
                .AsEnumerable()
                .FirstOrDefault();

            if (supplierDetails == null)
            {
                return NotFound();
            }

            return Ok(supplierDetails);
        }
    }
}
