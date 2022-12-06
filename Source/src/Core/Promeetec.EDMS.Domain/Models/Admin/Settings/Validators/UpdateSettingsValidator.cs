using FluentValidation;
using Promeetec.EDMS.Domain.Models.Admin.Settings.Commands;

namespace Promeetec.EDMS.Domain.Models.Admin.Settings.Validators;

public class UpdateSettingsValidator : AbstractValidator<UpdateSettings>
{
    public UpdateSettingsValidator()
    {
        RuleFor(c => c.Straat)
            .NotEmpty().WithMessage("Straat is verplicht.")
            .Length(200).WithMessage("Straat kan maximaal 200 tekens lang zijn.");

        RuleFor(c => c.Huisnummer)
            .NotEmpty().WithMessage("Huisnummer is verplicht.")
            .Length(50).WithMessage("Huisnummer kan maximaal 50 tekens lang zijn.");

        RuleFor(c => c.Huisnummertoevoeging)
            .Length(50).WithMessage("Huisnummertoevoeging kan maximaal 50 tekens lang zijn.");

        RuleFor(c => c.Postcode)
            .NotEmpty().WithMessage("Postcode is verplicht.")
            .Length(50).WithMessage("Postcode kan maximaal 50 tekens lang zijn.");

        RuleFor(c => c.Woonplaats)
            .NotEmpty().WithMessage("Woonplaats is verplicht.")
            .Length(200).WithMessage("Woonplaats kan maximaal 200 tekens lang zijn.");

        RuleFor(c => c.Telefoon)
            .Length(15).WithMessage("Telefoon kan maximaal 15 tekens lang zijn.");

        RuleFor(c => c.Email)
            .Length(450).WithMessage("E-mail kan maximaal 450 tekens lang zijn.");

        RuleFor(c => c.Haarwerk.BedragBasisVerzekeringHaarwerk)
            .NotEmpty().WithMessage("Bedrag basis verzekering is verplicht.");
    }
}
