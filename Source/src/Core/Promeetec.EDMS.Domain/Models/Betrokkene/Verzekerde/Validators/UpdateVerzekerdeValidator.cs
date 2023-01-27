using System.Text.RegularExpressions;
using FluentValidation;
using Promeetec.EDMS.Portaal.Core;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde.Validators.Rules;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde.Validators;

public class UpdateVerzekerdeValidator : AbstractValidator<UpdateVerzekerde>
{
    public UpdateVerzekerdeValidator(IDispatcher dispatcher)
    {
        RuleFor(c => c.Persoon.Geslacht)
            .IsInEnum().WithMessage("Geslacht is verplicht.");

        RuleFor(c => c.Persoon.Voorletters)
            .NotEmpty().WithMessage("Voorletters is verplicht.")
            .MaximumLength(20).WithMessage("Voorletters kan maximaal 20 tekens lang zijn.");

        RuleFor(c => c.Persoon.Tussenvoegsel)
            .MaximumLength(20).WithMessage("Tussenvoegsel kan maximaal 20 tekens lang zijn.");

        RuleFor(c => c.Persoon.Voornaam)
            .MaximumLength(200).WithMessage("Voornaam kan maximaal 200 tekens lang zijn.")
            .Matches(new Regex(@"^(?:[u00C0-\u017Fa-zA-Z\-]+\s?)+[u00C0-\u017Fa-zA-Z\-]+$")).WithMessage("Alleen letters, spaties en koppeltekens zijn toegestaan.");

        RuleFor(c => c.Persoon.Achternaam)
            .NotEmpty().WithMessage("Achternaam is verplicht.")
            .MaximumLength(256).WithMessage("Achternaam kan maximaal 256 tekens lang zijn.")
            .Matches(new Regex(@"^(?:[u00C0-\u017Fa-zA-Z\-]+\s?)+[u00C0-\u017Fa-zA-Z\-]+$")).WithMessage("Alleen letters, spaties en koppeltekens zijn toegestaan.");

        RuleFor(c => c.Persoon.Geboortedatum)
            .NotEmpty().WithMessage("Geboortedatum is verplicht.")
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("Geboortedatum kan niet in de toekomst liggen!")
            .Must(BeValidDate)
            .WithMessage("Geboortedatum is ongeldig!");

        RuleFor(c => c.Bsn)
            .NotEmpty().WithMessage("Burgerservicenummer is verplicht.")
            .Must(BeValidBsn)
            .WithMessage("Dit is geen geldig burgerservicenummer!")
            .MustAsync((c, p, cancellation) => dispatcher.Get(new IsBsnUnique { Bsn = c.Bsn }))
            .WithMessage(c => "Er bestaat al een cliënt met hetzelfde burgerservicenummer!");

        RuleFor(c => c.Adres.LandId)
            .NotEmpty().WithMessage("Land is verplicht.");

        RuleFor(c => c.Zorgverzekering.VerzekeraarId)
            .NotEmpty().WithMessage("Verzekeraar is verplicht.");
    }

    private bool BeValidBsn(string clientBsn)
    {
        if (string.IsNullOrWhiteSpace(clientBsn))
            return false;

        var bsn = clientBsn;
        if (bsn.Length == 8)
            bsn = "0" + bsn;

        int.TryParse(bsn, out var bsnNummer);
        if (bsnNummer <= 9999999 || bsnNummer > 999999999)
            return false;

        int sum = -1 * bsnNummer % 10;

        for (int multiplier = 2; bsnNummer > 0; multiplier++)
        {
            int val = (bsnNummer /= 10) % 10;
            sum += multiplier * val;
        }

        return sum != 0 && sum % 11 == 0;
    }

    private bool BeValidDate(DateTime? date)
    {
        if (!date.HasValue)
            return true;

        var regex = new Regex("^(0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-](19|20)\\d\\d$");
        var match = regex.Match(date.Value.ToString());
        return match.Success;
    }
}
