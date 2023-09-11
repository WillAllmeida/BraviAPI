using Domain.Models;
using FluentValidation;

namespace Application.Validators;

public class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(u => u.Name).NotEmpty().NotNull().MaximumLength(100);
    }
}
