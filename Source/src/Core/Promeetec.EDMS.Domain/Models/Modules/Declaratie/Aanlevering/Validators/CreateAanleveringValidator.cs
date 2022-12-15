using FluentValidation;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering.Commands;

namespace Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering.Validators;

public class CreateAanleveringValidator : AbstractValidator<CreateAanlevering>
{
    public CreateAanleveringValidator()
    {
        RuleFor(c => c.Referentie)
            .NotEmpty().WithMessage("Referentie is verplicht.")
            .MaximumLength(200).WithMessage("Referentie kan maximaal 200 tekens lang zijn.");

        RuleFor(c => c.ReferentiePromeetec)
            .MaximumLength(200).WithMessage("Referentie kan maximaal 200 tekens lang zijn.");

        RuleFor(c => c.Opmerking)
            .MaximumLength(1024).WithMessage("Referentie kan maximaal 1024 tekens lang zijn.");
        
        RuleFor(c => c.EigenaarId)
            .NotEmpty().WithMessage("Eigenaar is verplicht.");

        RuleFor(c => c.BehandelaarId)
            .NotEmpty().WithMessage("Behandelaar is verplicht.");
    }
}
