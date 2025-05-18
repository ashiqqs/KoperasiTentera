using FluentValidation;

namespace KoperasiTentera.Models.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty().WithMessage("Name is requried")
                .MaximumLength(255);

            RuleFor(m => m.IcNumber)
                .NotEmpty()
                .NotNull().WithMessage("IC Number is requried")
                .MaximumLength(12);

            RuleFor(m => m.Email)
                .EmailAddress().WithMessage("Email address is not valid")
                .NotEmpty();

            RuleFor(m => m.ContactNumber)
                .NotEmpty().WithMessage("Contact Number is required")
                .NotNull().WithMessage("Contact Number is required");
        }
    }
}
