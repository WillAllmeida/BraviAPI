using Domain.Entities;
using Domain.Enums;
using FluentValidation;

namespace Application.Validators;

public class ContactValueValidator : AbstractValidator<Tuple<string, ContactType>>
{
    public ContactValueValidator()
    {
        RuleFor(v => v.Item1).EmailAddress().When(v => v.Item2 == ContactType.Email);
        RuleFor(v => v.Item1).NotEmpty().NotNull().Length(11).Matches("^[0-9]+$").When(v => v.Item2 == ContactType.Whatsapp).WithMessage("Número de whatsapp inserido em formato incorreto");
        RuleFor(v => v.Item1).NotEmpty().NotNull().Length(11).Matches("^[0-9]+$").When(v => v.Item2 == ContactType.Telephone).WithMessage("Número de telefone inserido em formato incorreto");
    }
}
