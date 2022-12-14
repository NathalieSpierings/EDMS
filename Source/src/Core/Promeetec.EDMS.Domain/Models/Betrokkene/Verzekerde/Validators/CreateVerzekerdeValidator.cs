using System.Text.RegularExpressions;
using FluentValidation;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Validators.Rules;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Validators;

public class CreateVerzekerdeValidator : AbstractValidator<CreateVerzekerde>
{
    public CreateVerzekerdeValidator(IDispatcher dispatcher)
    {
        RuleFor(c => c.Persoon.Geslacht)
            .IsInEnum().WithMessage("Geslacht is verplicht.");

        RuleFor(c => c.Persoon.Voorletters)
            .NotEmpty().WithMessage("Voorletters is verplicht.")
            .Length(1, 20).WithMessage("Voorletters kan maximaal 20 tekens lang zijn.");

        RuleFor(c => c.Persoon.Tussenvoegsel)
            .Length(1, 20).WithMessage("Tussenvoegsel kan maximaal 20 tekens lang zijn.");

        RuleFor(c => c.Persoon.Voornaam)
            .Length(1, 200).WithMessage("Voornaam kan maximaal 200 tekens lang zijn.")
            .Matches(new Regex(@"^(?:[u00C0-\u017Fa-zA-Z\-]+\s?)+[u00C0-\u017Fa-zA-Z\-]+$")).WithMessage("Alleen letters, spaties en koppeltekens zijn toegestaan.");

        RuleFor(c => c.Persoon.Achternaam)
            .NotEmpty().WithMessage("Achternaam is verplicht.")
            .Length(1, 256).WithMessage("Achternaam kan maximaal 256 tekens lang zijn.")
            .Matches(new Regex(@"^(?:[u00C0-\u017Fa-zA-Z\-]+\s?)+[u00C0-\u017Fa-zA-Z\-]+$")).WithMessage("Alleen letters, spaties en koppeltekens zijn toegestaan.");


        RuleFor(c => c.Persoon.Geboortedatum)
            .NotEmpty().WithMessage("Geboortedatum is verplicht.")
            .InclusiveBetween(new DateTime(1900, 1, 1), DateTime.Now)
            .MustAsync((c, p, cancellation) => dispatcher.Get(new IsGeboortedatumValid { Geboortedatum = c.Persoon.Geboortedatum }))
            .WithMessage(c => "De geboortedatum kan niet in de toekomst liggen!");


        RuleFor(c => c.Bsn)
            .NotEmpty().WithMessage("Bsn is verplicht.")
            .Length(8, 9).WithMessage("Bsn bestaat uit 9 cijfers.")
            .MustAsync((c, p, cancellation) => dispatcher.Get(new IsBsnValid { Bsn = c.Bsn }))
            .WithMessage(c => $"{c.Bsn} is geen geldig burgerservicenummer.")
            .MustAsync((c, p, cancellation) => dispatcher.Get(new IsBsnUnique { Bsn = c.Bsn }))
            .WithMessage(c => "Er bestaat al een cliënt met hetzelfde burgerservicenummer!");


        RuleFor(c => c.Adres.LandId)
            .NotEmpty().WithMessage("Land is verplicht.");

        RuleFor(c => c.Zorgverzekering.VerzekeraarId)
            .NotEmpty().WithMessage("Verzekeraar is verplicht.");
    }
}
