using FluentValidation;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan.Commands;
using Promeetec.EDMS.Domain.Models.Modules.GLI.Behandelplan.Validators.Rules;

namespace Promeetec.EDMS.Domain.Models.Modules.GLI.Behandelplan.Validators;

public class StartBehandeltrajectValidator : AbstractValidator<StartBehandeltraject>
{
    public StartBehandeltrajectValidator(IDispatcher dispatcher)
    {

        RuleFor(c => c.Startdatum)
            .NotEmpty().WithMessage("Startdatum is verplicht.")
            .InclusiveBetween(new DateTime(1900, 1, 1), DateTime.Now)
            .MustAsync((c, p, cancellation) => dispatcher.Get(new IsStartdatumValid { Startdatum = c.Startdatum }))
            .WithMessage(c => "Dit is geen geldige datum!")
            .MustAsync((c, p, cancellation) => dispatcher.Get(new IsStartdatumAfterIntakedatum { Intakedatum = p, Startdatum = c.Startdatum }))
            .WithMessage(c => "De startdatum kan niet voor de intake datum liggen!");


        RuleFor(c => c.Einddatum)
            .InclusiveBetween(new DateTime(1900, 1, 1), DateTime.Now)
            .MustAsync((c, p, cancellation) => dispatcher.Get(new IsEinddatumValid { Einddatum = c.Startdatum }))
            .WithMessage(c => "Dit is geen geldige datum!");

        RuleFor(c => c.Programma)
            .IsInEnum().WithMessage("Programma is verplicht.");

        RuleFor(c => c.VerzekerdeId)
            .NotEmpty().WithMessage("Verzekerde is verplicht.");

        RuleFor(c => c.BehandelaarId)
            .NotEmpty().WithMessage("Behandelaar is verplicht.");
    }
}
