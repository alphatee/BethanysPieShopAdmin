using FluentValidation;

namespace BethanysPieShopAdmin.Models.Validators
{
    public class IngredientValidator: AbstractValidator<Ingredient>
    {
        public IngredientValidator() 
        {
            RuleFor(ingredient => ingredient.Name)
                .NotEmpty().WithMessage("Please enter the ingredient name.")
                .Length(1, 50).WithMessage("The name should be no longer than 50 characters.");

            RuleFor(ingredient => ingredient.Amount)
                .NotEmpty().WithMessage("Please enter the ingredient amount.")
                .Length(1, 100).WithMessage("The amount should be no longer than 100 characters.");
        }
    }
}
