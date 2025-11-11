using System.ComponentModel.DataAnnotations;

namespace BethanysPieShopAdmin.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [StringLength(50, ErrorMessage = "The name should be no longer than 50 characters.")]
        [Display(Name = "Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Description")]
        [StringLength(1000, ErrorMessage = "The description should be no longer than 1000 characters.")]
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date added")]
        [CustomValidation(typeof(Category), nameof(ValidateDateAdded))]
        public DateTime? DateAdded { get; set; }

        public ICollection<Pie>? Pies { get; set; }

        // Custom validation method for DateAdded
        public static ValidationResult ValidateDateAdded(DateTime? date, ValidationContext context)
        {
            if (date.HasValue && date.Value > DateTime.Today)
            {
                return new ValidationResult("Date cannot be in the future");
            }
            return ValidationResult.Success;
        }
    }
}
