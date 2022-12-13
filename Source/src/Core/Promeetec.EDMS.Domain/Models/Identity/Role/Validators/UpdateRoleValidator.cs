using FluentValidation;
using Promeetec.EDMS.Domain.Models.Identity.Role.Commands;

namespace Promeetec.EDMS.Domain.Models.Identity.Role.Validators;

public class UpdateRoleValidator : AbstractValidator<UpdateRole>
{
    public UpdateRoleValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Naam is verplicht.")
            .Length(200).WithMessage("Naam kan maximaal 200 tekens lang zijn.");

        RuleFor(c => c.Description)
            .NotEmpty().WithMessage("Omschrijving is verplicht.")
            .Length(1024).WithMessage("Omschrijving kan maximaal 450 tekens lang zijn.");
    }
}
