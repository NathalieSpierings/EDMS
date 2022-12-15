using System.Text.RegularExpressions;
using FluentValidation;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan.Commands;

namespace Promeetec.EDMS.Domain.Models.Modules.GLI.Behandelplan.Validators;

public class StartBehandeltrajectValidator : AbstractValidator<StartBehandeltraject>
{
    public StartBehandeltrajectValidator()
    {
        RuleFor(x => x.Startdatum)
            .NotEmpty()
            .WithMessage("Startdatum is verplicht.")
            .LessThanOrEqualTo(x => x.Intakedatum)
            .WithMessage("De startdatum kan niet voor de intake datum liggen!")
            .Must(BeValidDate)
            .WithMessage("Startdatum is ongeldig!");

        RuleFor(c => c.Programma)
            .IsInEnum().WithMessage("Programma is verplicht.");

        RuleFor(c => c.VerzekerdeId)
            .NotEmpty().WithMessage("Cliënt is verplicht.");

        RuleFor(c => c.BehandelaarId)
            .NotEmpty().WithMessage("Behandelaar is verplicht.");
        
    }
    private bool BeValidDate(DateTime date)
    {
        var regex = new Regex("^(0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-](19|20)\\d\\d$");
        var match = regex.Match(date.ToString());
        return match.Success;
    }
}
