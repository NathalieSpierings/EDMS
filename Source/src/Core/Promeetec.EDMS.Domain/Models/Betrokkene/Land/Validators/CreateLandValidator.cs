using FluentValidation;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Land.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Land.Validators;

public class CreateLandValidator : AbstractValidator<CreateLand>
{
    public CreateLandValidator()
    {
        RuleFor(c => c.CultureCode)
            .NotEmpty().WithMessage("CultureCode is verplicht.")
            .Length(2, 50).WithMessage("CultureCode kan maximaal 50 tekens lang zijn.");

        RuleFor(c => c.NativeName)
            .NotEmpty().WithMessage("NativeName is verplicht.")
            .Length(1, 128).WithMessage("NativeName kan maximaal 128 tekens lang zijn.");
    }
}
