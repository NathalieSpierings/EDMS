using FluentValidation;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Validators;

public class UpdateOrganisatieValidator : AbstractValidator<UpdateOrganisatie>
{
    public UpdateOrganisatieValidator()
    {
        RuleFor(c => c.Naam)
            .NotEmpty().WithMessage("Naam is verplicht.")
            .Length(1, 200).WithMessage("Naam moet minimaal 1 en maximaal 200 tekens lang zijn.");

        RuleFor(c => c.AgbCodeOnderneming)
            .NotEmpty().WithMessage("AGB-code onderneming  is verplicht.")
            .Length(8, 200).WithMessage("AGB-code onderneming bestaat uit 8 cijfers!");

        RuleFor(c => c.TelefoonZakelijk)
            .Length(10, 15).WithMessage("Telefoonnummer zakelijk moet minimaal 10 cijfers bevatten en mag niet langer zijn dan 15 cijfers.");

        RuleFor(c => c.TelefoonPrive)
            .Length(10, 15).WithMessage("Telefoonnummer privé moet minimaal 10 cijfers bevatten en mag niet langer zijn dan 15 cijfers.");

        RuleFor(c => c.Email)
            .Length(6, 450).WithMessage("E-mail moet minimaal 6 en maximaal 450 tekens lang zijn.")
            .EmailAddress().WithMessage("Dit is geen geldig e-mailadres!");

        RuleFor(c => c.Website)
            .Length(9, 256).WithMessage("Website moet minimaal 9 en maximaal 256 tekens lang zijn.")
            .Must(BeAValidUrl).WithMessage("Dit is geen geldige website URL. HTTP://www.xx.nl");

        RuleFor(c => c.ContactpersoonId)
            .NotEmpty().WithMessage("Contactpersoon is verplicht.");
    }

    private static bool BeAValidUrl(string arg)
    {
        Uri result;
        return Uri.TryCreate(arg, UriKind.Absolute, out result);
    }
}