using FluentValidation;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering.Validators;

public class WijzigEigenaarValidator : AbstractValidator<ChangeEigenaarAanlevering>
{
    public WijzigEigenaarValidator()
    {
        RuleFor(c => c.EigenaarId)
            .NotEmpty().WithMessage("Eigenaar is verplicht.");
    }
}
