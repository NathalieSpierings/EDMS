using FluentValidation;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Validators;

public class UpdatePasswordValidator : AbstractValidator<UpdatePassword>
{
    public UpdatePasswordValidator()
    {
        RuleFor(c => c.Password)
            .NotEmpty().WithMessage("Wachtwoord is verplicht.");
    }
}
