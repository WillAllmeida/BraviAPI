using Domain.Enums;
using Domain.Models;
using FluentValidation;

namespace Application.Validators;

public class UpdateContactValidator : AbstractValidator<UpdateContactRequest>
{
    public UpdateContactValidator()
    {
        RuleFor(c => c.Value).NotEmpty().NotNull().MaximumLength(100);
        RuleFor(c => c.Id).GreaterThan(0);
        RuleFor(c => new Tuple<string, ContactType>(c.Value, c.Type)).SetValidator(new ContactValueValidator());

    }
}
