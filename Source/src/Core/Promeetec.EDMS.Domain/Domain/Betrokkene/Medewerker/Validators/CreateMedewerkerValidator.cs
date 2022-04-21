using FluentValidation;
using Promeetec.EDMS.Domain.Domain.Betrokkene.Medewerker.Commands;

namespace Promeetec.EDMS.Domain.Domain.Betrokkene.Medewerker.Validators;

public class CreateMedewerkerValidator : AbstractValidator<CreateMedewerker>
{
    public CreateMedewerkerValidator(IMedewerkerRules rules)
    {

        RuleFor(c => c.Persoon.Voorletters)
            .NotEmpty().WithMessage("Voorletters is verplicht.")
            .MaximumLength(20).WithMessage("Voorletters kan maximaal 20 tekens bevatten.");

        RuleFor(c => c.Persoon.Achternaam)
            .NotEmpty().WithMessage("Achternaam is verplicht.")
            .MaximumLength(200).WithMessage("Voorletters mag maximaal 200 tekens bevatten.");


        RuleFor(c => c.Persoon.Email)
            .NotEmpty().WithMessage("E-mail is verplicht.")
            .EmailAddress().WithMessage("Dit is geen geldig e-mailadres.");
    }
}