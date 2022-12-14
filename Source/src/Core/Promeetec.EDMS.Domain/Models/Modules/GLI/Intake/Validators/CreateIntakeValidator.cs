using FluentValidation;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Intake.Commands;
using Promeetec.EDMS.Domain.Models.Modules.GLI.Intake.Validators.Rules;

namespace Promeetec.EDMS.Domain.Models.Modules.GLI.Intake.Validators;

public class CreateIntakeValidator : AbstractValidator<CreateIntake>
{
    public CreateIntakeValidator(IDispatcher dispatcher)
    {

        RuleFor(c => c.IntakeDatum)
            .NotEmpty().WithMessage("Intake datum is verplicht.")
            .InclusiveBetween(new DateTime(1900, 1, 1), DateTime.Now)
            .MustAsync((c, p, cancellation) => dispatcher.Get(new IsIntakedatumValid { Intakedatum = c.IntakeDatum }))
            .WithMessage(c => "De intake datum kan niet in de toekomst liggen!");

        RuleFor(c => c.BehandelaarId)
            .NotEmpty().WithMessage("Behandelaar is verplicht.");
    }
}
