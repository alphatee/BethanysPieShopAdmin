using FluentValidation;

namespace BethanysPieShopAdmin.Models.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("The category name is required.")
                .Length(1, 50).WithMessage("The name should be no longer than 50 characters.");

            // Description is a nullable string (string?) so we use When()
            RuleFor(c => c.Description)
                .MaximumLength(1000).When(c => c.Description != null)
                .WithMessage("The description should be no longer than 1000 characters.");
        }
    }
}
