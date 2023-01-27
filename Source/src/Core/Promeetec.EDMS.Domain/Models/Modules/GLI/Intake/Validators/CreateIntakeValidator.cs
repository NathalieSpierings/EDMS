using System.Text.RegularExpressions;
using FluentValidation;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake.Validators;

public class CreateIntakeValidator : AbstractValidator<CreateIntake>
{
    public CreateIntakeValidator()
    {
        RuleFor(x => x.IntakeDatum)
            .NotEmpty().WithMessage("Intakedatum is verplicht.")
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage(c => "De intake datum kan niet in de toekomst liggen!")
            .Must(BeValidDate)
            .WithMessage("Intakedatum is ongeldig!");

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
