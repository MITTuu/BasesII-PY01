using System.ComponentModel.DataAnnotations;
using System.Text;

namespace API_Core.Models
{
    public class SupplierDetails
    {
        [Key]
        public required int SupplierID { get; set; }
        public string? SupplierReference { get; set; }
        public required string SupplierName { get; set; }
        public string? SupplierCategoryName { get; set; }
        public string? PrimaryContact {  get; set; }
        public string? AlternateContact { get; set; }
        public string? DeliveryMethodName { get; set;}
        public string? DeliveryCity { get; set;}
        public required string DeliveryPostalCode {  get; set; }
        public required string PhoneNumber { get; set; }
        public required string FaxNumber { get; set;}
        public required string WebsiteURL { get; set; }
        public required string DeliveryPostal1 { get; set; }
        public required string DeliveryPostal2 {  get; set; }
        public string? DeliveryLocation { get; set; }
        public string? BankAccountName { get; set; }
        public string? BankAccountNumber { get; set; }
        public required int PaymentDays { get; set; }
    }
}