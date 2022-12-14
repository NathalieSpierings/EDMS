using FluentValidation;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht.Commands;

namespace Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht.Validators;

public class CreateAanleverberichtValidator : AbstractValidator<CreateAanleverbericht>
{
    public CreateAanleverberichtValidator()
    {
        RuleFor(c => c.Bericht)
            .NotEmpty().WithMessage("Bericht is verplicht.")
            .Length(10000).WithMessage("Bericht kan maximaal 10000 tekens lang zijn.");
    }
}
