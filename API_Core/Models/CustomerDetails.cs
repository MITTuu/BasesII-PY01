using System.ComponentModel.DataAnnotations;

namespace API_Core.Models
{
    public class CustomerDetails
    {
        [Key] 
        public required int CustomerID { get; set; }
        public required string CustomerName { get; set; }
        public required string CustomerCategoryName { get; set; }
        public string? BuyingGroupName { get; set; }
        public required string PrimaryContact { get; set; }
        public string? AlternateContact { get; set; }
        public required string BillToCustomer { get; set; }
        public required string DeliveryMethodName { get; set; }
        public required string DeliveryCity { get; set; }
        public required string DeliveryPostalCode { get; set; }
        public required string PhoneNumber { get; set; }
        public required string FaxNumber { get; set; }
        public int PaymentDays { get; set; }
        public required string WebsiteURL { get; set; }
        public required string DeliveryPostal1 { get; set; }
        public string? DeliveryPostal2 { get; set; }
        public string? DeliveryLocation { get; set; }
    }
}
