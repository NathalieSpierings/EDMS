using FluentValidation;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekeraar.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekeraar.Validators;

public class CreateVerzekeraarValidator : AbstractValidator<CreateVerzekeraar>
{
    public CreateVerzekeraarValidator()
    {
        RuleFor(c => c.Uzovi).NotEmpty().WithMessage("Uzovi is verplicht.");
        RuleFor(c => c.Naam).NotEmpty().Length(1, 256).WithMessage("Naam verzekeraar kan maximaal 256 tekens lang zijn.").WithMessage("Naam verzekeraar is verplicht.");
    }
}
