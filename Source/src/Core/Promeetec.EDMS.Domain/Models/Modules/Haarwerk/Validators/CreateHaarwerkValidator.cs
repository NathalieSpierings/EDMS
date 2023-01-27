using System.Text.RegularExpressions;
using FluentValidation;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Haarwerk.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Haarwerk.Validators;

public class CreateHaarwerkValidator : AbstractValidator<CreateHaarwerk>
{
    public CreateHaarwerkValidator()
    {
        RuleFor(c => c.Naam)
            .NotEmpty().WithMessage("Cliëntnaam is verplicht.")
            .Matches("@\"^(?:[u00C0-\\u017Fa-zA-Z\\-]+\\s?)+[u00C0-\\u017Fa-zA-Z\\-]+$\"")
            .WithMessage("Alleen letters, spaties en koppeltekens zijn toegestaan.")
            .MaximumLength(200).WithMessage("Cliëntnaam moet minimaal 1 en maximaal 200 tekens lang zijn.");

        RuleFor(c => c.Geboortedatum)
            .NotEmpty().WithMessage("Geboortedatum is verplicht.")
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("Geboortedatum kan niet in de toekomst liggen!")
            .Must(BeValidDate)
            .WithMessage("Geboortedatum is ongeldig!");

        RuleFor(c => c.Bsn)
            .NotEmpty().WithMessage("Burgerservicenummer is verplicht.")
            .Must(BeValidBsn)
            .WithMessage("Dit is geen geldig burgerservicenummer!");

        RuleFor(c => c.Afleverdatum)
            .NotEmpty().WithMessage("Afleverdatum is verplicht.")
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("Afleverdatum kan niet in de toekomst liggen!")
            .Must(BeValidDate)
            .WithMessage("Afleverdatum is ongeldig!");

        RuleFor(c => c.PrijsHaarwerk)
            .Must(NotNegativeOrZero)
            .WithMessage("Prijs haarwerk mag niet negatief of 0 zijn!");

        RuleFor(c => c.BedragAanvullendeVerzekering)
            .Must(NotNegativeOrZero)
            .WithMessage("Aanvullende verzekering mag niet negatief of 0 zijn!");
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

    private bool NotNegativeOrZero(decimal prijs)
    {
        var regex = new Regex("^(([1-9]{1}|[\\d]{2,})((\\.|,)[\\d]+)?)$|^(1\\.[\\d]+)$");
        var match = regex.Match(prijs.ToString());
        return match.Success;
    }

    private bool BeValidDate(DateTime date)
    {
        var regex = new Regex("^(0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-](19|20)\\d\\d$");
        var match = regex.Match(date.ToString());
        return match.Success;
    }
}
