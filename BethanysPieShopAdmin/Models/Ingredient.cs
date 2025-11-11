using System.ComponentModel.DataAnnotations;

namespace BethanysPieShopAdmin.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Amount")]
        public string Amount { get; set; } = string.Empty;
    }
}
