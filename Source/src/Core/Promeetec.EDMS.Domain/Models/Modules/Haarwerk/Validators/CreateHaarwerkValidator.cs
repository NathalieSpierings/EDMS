using FluentValidation;
using Promeetec.EDMS.Domain.Models.Modules.Haarwerk.Commands;

namespace Promeetec.EDMS.Domain.Models.Modules.Haarwerk.Validators;

public class CreateHaarwerkValidator : AbstractValidator<CreateHaarwerk>
{
    public CreateHaarwerkValidator(IDispatcher dispatcher)
    {
        RuleFor(c => c.Naam)
            .NotEmpty().WithMessage("Naam is verplicht.")
            .Length(1, 200).WithMessage("Naam moet minimaal 1 en maximaal 200 tekens lang zijn.");

        RuleFor(c => c.Geboortedatum)
            .NotEmpty().WithMessage("Geboortedatum is verplicht.");

    }

    private static bool BeAValidUrl(string arg)
    {
        Uri result;
        return Uri.TryCreate(arg, UriKind.Absolute, out result);
    }
}
