using FluentValidation;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker.Validators;

public class UpdatePasswordValidator : AbstractValidator<UpdatePassword>
{
    public UpdatePasswordValidator()
    {
        RuleFor(c => c.Password)
            .NotEmpty().WithMessage("Wachtwoord is verplicht.");
    }
}
