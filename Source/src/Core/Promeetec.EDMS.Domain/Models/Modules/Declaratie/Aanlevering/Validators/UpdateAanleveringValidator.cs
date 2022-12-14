using FluentValidation;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering.Commands;

namespace Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering.Validators;

public class UpdateAanleveringValidator : AbstractValidator<UpdateAanlevering>
{
    public UpdateAanleveringValidator()
    {
        RuleFor(c => c.Referentie)
            .NotEmpty().WithMessage("Referentie is verplicht.")
            .Length(200).WithMessage("Referentie kan maximaal 200 tekens lang zijn.");

        RuleFor(c => c.EigenaarId)
            .NotEmpty().WithMessage("Eigenaar is verplicht.");
    }
}
