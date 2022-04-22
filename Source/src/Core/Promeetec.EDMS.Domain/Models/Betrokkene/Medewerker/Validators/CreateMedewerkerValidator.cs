using FluentValidation;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Validators;

public class CreateMedewerkerValidator : AbstractValidator<CreateMedewerker>
{
    public CreateMedewerkerValidator()
    {
        RuleFor(c => c.Persoon.Geslacht)
            .NotEmpty().WithMessage("Geslacht is verplicht.");

        RuleFor(c => c.Persoon.Voorletters)
            .NotEmpty().WithMessage("Voorletters is verplicht.")
            .Length(1, 20).WithMessage("Voorletters kan maximaal 20 tekens lang zijn.");

        RuleFor(c => c.Persoon.Tussenvoegsel)
            .Length(1, 20).WithMessage("Tussenvoegsel kan maximaal 20 tekens lang zijn.");

        RuleFor(c => c.Persoon.Voornaam)
            .Length(1, 200).WithMessage("Voornaam kan maximaal 200 tekens lang zijn.");

        RuleFor(c => c.Persoon.Achternaam)
            .NotEmpty().WithMessage("Achternaam is verplicht.")
            .Length(1, 256).WithMessage("Achternaam kan maximaal 256 tekens lang zijn.");

        // TODO regex
        RuleFor(c => c.Persoon.TelefoonZakelijk)
            .Length(10, 15).WithMessage("Telefoon zakelijk moet minimaal 10 en maximaal 15 tekens lang zijn.");

        // TODO regex
        RuleFor(c => c.Persoon.TelefoonPrive)
            .Length(10, 15).WithMessage("Telefoon privé moet minimaal 10 en maximaal 15 tekens lang zijn.");


        RuleFor(c => c.Persoon.Doorkiesnummer)
            .Length(1, 50).WithMessage("Telefoon privé kan maximaal 50 tekens lang zijn.");

        RuleFor(c => c.Email)
            .Length(6, 450).WithMessage("E-mail moet minimaal 6 en maximaal 450 tekens lang zijn.")
            .EmailAddress().WithMessage("Dit is geen geldig e-mailadres!");

        
        RuleFor(c => c.AgbCodeOnderneming)
            .NotEmpty().WithMessage("AGB-codeOnderneming is verplicht.");

        RuleFor(c => c.Functie)
            .Length(1, 200).WithMessage("Functie kan maximaal 200 tekens lang zijn.");
    }
}
