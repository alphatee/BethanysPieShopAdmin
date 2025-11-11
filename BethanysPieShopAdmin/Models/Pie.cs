using System.ComponentModel.DataAnnotations;

namespace BethanysPieShopAdmin.Models
{
    public class Pie
    {
        public int PieId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Short description")]
        public string? ShortDescription { get; set; }

        [Display(Name = "Long description")]
        public string? LongDescription { get; set; }

        [Display(Name = "Allergy information")]
        public string? AllergyInformation { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public string? ImageThumbnailUrl { get; set; }

        public bool IsPieOfTheWeek { get; set; }

        public bool InStock { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }
        public ICollection<Ingredient>? Ingredients { get; set; }
    }
}
