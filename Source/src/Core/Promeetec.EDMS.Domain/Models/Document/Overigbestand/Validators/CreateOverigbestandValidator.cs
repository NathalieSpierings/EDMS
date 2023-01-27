using FluentValidation;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Overigbestand.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Document.Overigbestand.Validators;

public class CreateOverigbestandValidator : AbstractValidator<CreateOverigBestand>
{
    public CreateOverigbestandValidator()
    {
        RuleFor(c => c.FileName)
            .NotEmpty().WithMessage("Bestandsnaam is verplicht.")
            .Length(450).WithMessage("Bestandsnaam kan maximaal 450 tekens lang zijn.");

        RuleFor(c => c.EigenaarId)
            .NotEmpty().WithMessage("Eigenaar is verplicht.");
    }
}
