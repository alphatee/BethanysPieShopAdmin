using FluentValidation;

namespace BethanysPieShopAdmin.Models.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            // --- Translating Rules from Data Annotations ---

            RuleFor(order => order.FirstName)
                .NotEmpty().WithMessage("Please enter your first name")
                .Length(1, 50).WithMessage("First name must be between 1 and 50 characters.");

            RuleFor(order => order.LastName)
                .NotEmpty().WithMessage("Please enter your last name")
                .Length(1, 50).WithMessage("Last name must be between 1 and 50 characters.");

            RuleFor(order => order.AddressLine1)
                .NotEmpty().WithMessage("Please enter your address")
                .Length(1, 100).WithMessage("Address Line 1 must be between 1 and 100 characters.");

            // AddressLine2 is optional (nullable string), so we don't use NotEmpty()
            RuleFor(order => order.AddressLine2)
                 .MaximumLength(100).When(x => x.AddressLine2 != null);

            RuleFor(order => order.ZipCode)
                .NotEmpty().WithMessage("Please enter your zip code")
                // Original: [StringLength(10, MinimumLength = 4)]
                .Length(4, 10).WithMessage("Zip code must be between 4 and 10 characters.");

            RuleFor(order => order.City)
                .NotEmpty().WithMessage("Please enter your city")
                .Length(1, 50).WithMessage("City must be between 1 and 50 characters.");

            RuleFor(order => order.State)
                // State is optional
                .MaximumLength(10).When(x => x.State != null)
                .WithMessage("State must be 10 characters or less.");

            RuleFor(order => order.Country)
                .NotEmpty().WithMessage("Please enter your country")
                .Length(1, 50).WithMessage("Country must be between 1 and 50 characters.");

            RuleFor(order => order.PhoneNumber)
                .NotEmpty().WithMessage("Please enter your phone number")
                .Length(1, 25).WithMessage("Phone number must be between 1 and 25 characters.");
            // FluentValidation has no direct equivalent to [DataType(DataType.PhoneNumber)] for strict format checking, you can add a Regex if needed.

            RuleFor(order => order.Email)
                .NotEmpty().WithMessage("Please enter your email address")
                .Length(1, 50).WithMessage("Email must be between 1 and 50 characters.")
                .EmailAddress().WithMessage("The email address is not entered in a correct format");
            // The EmailAddress() helper method covers standard email regex validation.
        }
    }
}
