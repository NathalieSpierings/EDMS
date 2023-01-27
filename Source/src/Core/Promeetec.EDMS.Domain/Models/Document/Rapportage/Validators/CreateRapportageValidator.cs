using FluentValidation;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Rapportage.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Document.Rapportage.Validators;

public class CreateRapportageValidator : AbstractValidator<CreateRapportage>
{
    public CreateRapportageValidator()
    {
        RuleFor(c => c.FileName)
            .NotEmpty().WithMessage("Bestandsnaam is verplicht.")
            .Length(450).WithMessage("Bestandsnaam kan maximaal 450 tekens lang zijn.");
    }
}
