using System.Text.RegularExpressions;
using FluentValidation;
using Promeetec.EDMS.Domain.Models.Admin.Settings.Commands;

namespace Promeetec.EDMS.Domain.Models.Admin.Settings.Validators;

public class UpdateSettingsValidator : AbstractValidator<UpdateSettings>
{
    public UpdateSettingsValidator()
    {
        RuleFor(c => c.Straat)
            .NotEmpty().WithMessage("Straat is verplicht.")
            .MaximumLength(200).WithMessage("Straat kan maximaal 200 tekens lang zijn.");

        RuleFor(c => c.Huisnummer)
            .NotEmpty().WithMessage("Huisnummer is verplicht.")
            .MaximumLength(50).WithMessage("Huisnummer kan maximaal 50 tekens lang zijn.");

        RuleFor(c => c.Huisnummertoevoeging)
            .MaximumLength(50).WithMessage("Huisnummertoevoeging kan maximaal 50 tekens lang zijn.");

        RuleFor(c => c.Postcode)
            .NotEmpty().WithMessage("Postcode is verplicht.")
            .MaximumLength(50).WithMessage("Postcode kan maximaal 50 tekens lang zijn.");

        RuleFor(c => c.Woonplaats)
            .NotEmpty().WithMessage("Woonplaats is verplicht.")
            .MaximumLength(200).WithMessage("Woonplaats kan maximaal 200 tekens lang zijn.");

        RuleFor(c => c.Telefoon)
            .Length(10, 15).WithMessage("Telefoonnummer moet minimaal 10 cijfers bevatten en mag niet langer zijn dan 15 cijfers.");

        RuleFor(c => c.Email)
            .EmailAddress().WithMessage("Dit is geen geldig e-mail adres!")
            .MaximumLength(450).WithMessage("E-mail kan maximaal 450 tekens lang zijn.");

        RuleFor(c => c.Haarwerk.BedragBasisVerzekeringHaarwerk)
            .Must(NotNegativeOrZero)
            .WithMessage("Bedrag basisverzekering mag niet negatief of 0 zijn!")
            .NotEmpty().WithMessage("Bedrag basis verzekering is verplicht.");
    }

    private bool NotNegativeOrZero(decimal prijs)
    {
        var regex = new Regex("^(([1-9]{1}|[\\d]{2,})((\\.|,)[\\d]+)?)$|^(1\\.[\\d]+)$");
        var match = regex.Match(prijs.ToString());
        return match.Success;
    }
}
