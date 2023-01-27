using FluentValidation;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Bestand.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Document.Bestand.Validators;

public class CreateBestandValidator : AbstractValidator<CreateBestand>
{
    public CreateBestandValidator()
    {
        RuleFor(c => c.FileName)
            .NotEmpty().WithMessage("Bestandsnaam is verplicht.")
            .Length(450).WithMessage("Bestandsnaam kan maximaal 450 tekens lang zijn.");
    }
}
