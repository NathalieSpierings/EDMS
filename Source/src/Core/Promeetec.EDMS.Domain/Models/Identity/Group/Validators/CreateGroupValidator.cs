using FluentValidation;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Group.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Identity.Group.Validators;

public class CreateGroupValidator : AbstractValidator<CreateGroup>
{
    public CreateGroupValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Naam is verplicht.")
            .Length(200).WithMessage("Naam kan maximaal 200 tekens lang zijn.");

        RuleFor(c => c.Description)
            .NotEmpty().WithMessage("Omschrijving is verplicht.")
            .Length(1024).WithMessage("Omschrijving kan maximaal 450 tekens lang zijn.");
        
    }
}
