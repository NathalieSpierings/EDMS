using System.Text.RegularExpressions;
using FluentValidation;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Validators;

public class UpdateVerbruiksmiddelPrestatieValidator : AbstractValidator<UpdateVerbruiksmiddelPrestatie>
{
    public UpdateVerbruiksmiddelPrestatieValidator()
    {
        RuleFor(c => c.ZIndex)
            .NotEmpty().WithMessage("Z-index nummer is verplicht.")
            .GreaterThan(0)
            .WithMessage("Z-index mag niet 0 zijn");

        RuleFor(c => c.PrestatieDatum)
            .NotEmpty().WithMessage("Prestatie datum is verplicht.")
            .Must(BeValidDate)
            .WithMessage("Prestatie datum is ongeldig!");

        RuleFor(c => c.Hoeveelheid)
            .NotEmpty().WithMessage("Hoeveelheid is verplicht.")
            .GreaterThan(0)
            .WithMessage("Hoeveelheid mag niet 0 zijn");
    }

    private bool BeValidDate(DateTime? date)
    {
        if (!date.HasValue)
            return true;

        var regex = new Regex("^(0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-](19|20)\\d\\d$");
        var match = regex.Match(date.Value.ToString());
        return match.Success;
    }
}
