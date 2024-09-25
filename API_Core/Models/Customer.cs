using System.ComponentModel.DataAnnotations;

namespace API_Core.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public required string CustomerName { get; set; }
        public required string CustomerCategoryName { get; set; }
        public required string DeliveryMethodName { get; set; }
    }
}
