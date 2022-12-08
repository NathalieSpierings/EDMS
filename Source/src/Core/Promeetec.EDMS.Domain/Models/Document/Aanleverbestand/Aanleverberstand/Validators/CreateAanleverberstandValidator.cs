using FluentValidation;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Commands;

namespace Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Validators;

public class CreateAanleverbestandValidator : AbstractValidator<CreateAanleverbestand>
{
    public CreateAanleverbestandValidator()
    {
        RuleFor(c => c.FileName)
            .NotEmpty().WithMessage("Bestandsnaam is verplicht.")
            .Length(450).WithMessage("Bestandsnaam kan maximaal 450 tekens lang zijn.");

        RuleFor(c => c.EigenaarId)
            .NotEmpty().WithMessage("Eigenaar is verplicht.");
    }
}
