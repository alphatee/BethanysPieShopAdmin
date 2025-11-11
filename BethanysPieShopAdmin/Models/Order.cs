using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace BethanysPieShopAdmin.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }

        public ICollection<OrderDetail>? OrderDetails { get; set; }

        public OrderStatus OrderStatus { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Last name")]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; } = string.Empty;

        [Display(Name = "Address Line 2")]
        public string? AddressLine2 { get; set; }

        [Display(Name = "Zip code")]
        public string ZipCode { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string? State { get; set; }

        public string Country { get; set; } = string.Empty;

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [BindNever]
        [ScaffoldColumn(false)]
        public decimal OrderTotal { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderPlaced { get; set; }
    }
}
