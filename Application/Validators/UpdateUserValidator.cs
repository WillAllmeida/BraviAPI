using Domain.Models;
using FluentValidation;

namespace Application.Validators;

public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserValidator()
    {
        RuleFor(u => u.Name).NotEmpty().NotNull().MaximumLength(100);
        RuleFor(u => u.Id).GreaterThan(0);
    }
}
