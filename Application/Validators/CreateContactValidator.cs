using Domain.Enums;
using Domain.Models;
using FluentValidation;

namespace Application.Validators;

public class CreateContactValidator : AbstractValidator<CreateContactRequest>
{
    public CreateContactValidator()
    {
        RuleFor(c => c.UserId).GreaterThan(0);
        RuleFor(c => c.Type).IsInEnum();
        RuleFor(c => new Tuple<string, ContactType>(c.Value, c.Type)).SetValidator(new ContactValueValidator());
    }
}
