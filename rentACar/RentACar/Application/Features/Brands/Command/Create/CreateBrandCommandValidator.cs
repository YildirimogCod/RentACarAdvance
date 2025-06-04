using FluentValidation;

namespace Application.Features.Brands.Command.Create
{
    public class CreateBrandCommandValidator:AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Brand name is required.")
                .MaximumLength(50).WithMessage("Brand name must not exceed 50 characters.");
        }
    }
}
