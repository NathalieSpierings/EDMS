using FluentValidation;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.Zorgstraat.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Admin.Zorgstraat.Validators;

public class CreateZorgstraatValidator : AbstractValidator<CreateZorgstraat>
{
    public CreateZorgstraatValidator()
    {
        RuleFor(c => c.Naam)
            .NotEmpty().WithMessage("Naam is verplicht.")
            .Length(200).WithMessage("Naam kan maximaal 200 tekens lang zijn.");
    }
}
