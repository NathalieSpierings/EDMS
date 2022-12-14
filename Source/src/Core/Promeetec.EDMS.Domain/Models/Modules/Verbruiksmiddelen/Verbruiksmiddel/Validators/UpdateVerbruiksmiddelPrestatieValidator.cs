using FluentValidation;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Commands;

namespace Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Validators;

public class UpdateVerbruiksmiddelPrestatieValidator : AbstractValidator<UpdateVerbruiksmiddelPrestatie>
{
    public UpdateVerbruiksmiddelPrestatieValidator()
    {
        RuleFor(c => c.AgbCodeOnderneming)
            .NotEmpty().WithMessage("AGBCode oOnderneming is verplicht.")
            .Length(8).WithMessage("AGBCode onderneming kan maximaal 8 tekens lang zijn.");
    }
}
