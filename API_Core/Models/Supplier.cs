using System.ComponentModel.DataAnnotations;

namespace API_Core.Models
{
    public class Supplier
    {
        [Key]
        public required int SupplierID { get; set; }
        public required string SupplierName { get; set; }
        public string? SupplierCategoryName { get; set; }
        public string? DeliveryMethodName { get; set; }
    }
}
