using System.Text.RegularExpressions;
using FluentValidation;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Validators;

public class UpdateVerzekerdeValidator : AbstractValidator<UpdateVerzekerde>
{
    public UpdateVerzekerdeValidator(IDispatcher dispatcher)
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
            .InclusiveBetween(new DateTime(1900, 1, 1), DateTime.Now);


        RuleFor(c => c.Bsn)
            .NotEmpty().WithMessage("Bsn is verplicht.")
            .Length(8, 9).WithMessage("Bsn bestaat uit 9 cijfers.")
            .Must(BeAValidBsn).WithMessage(c => $"{c.Bsn} is geen geldig burgerservicenummer.");



        RuleFor(c => c.Adres.LandId)
            .NotEmpty().WithMessage("Land is verplicht.");

        RuleFor(c => c.Zorgverzekering.VerzekeraarId)
            .NotEmpty().WithMessage("Verzekeraar is verplicht.");
    }

    private static bool BeAValidBsn(string bsn)
    {
        if (bsn.Length == 8)
            bsn = "0" + bsn;

        var isValid = IsValidBSN(bsn);
        return isValid;
    }

    private static bool IsValidBSN(string bsn)
    {
        int.TryParse(bsn, out var bsnNummer);
        if (bsnNummer <= 9999999 || bsnNummer > 999999999)
        {
            return false;
        }

        int sum = -1 * bsnNummer % 10;

        for (int multiplier = 2; bsnNummer > 0; multiplier++)
        {
            int val = (bsnNummer /= 10) % 10;
            sum += multiplier * val;
        }

        return sum != 0 && sum % 11 == 0;
    }
}
