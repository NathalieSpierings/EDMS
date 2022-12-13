using FluentValidation;
using Promeetec.EDMS.Domain.Models.Menu.MenuItem.Commands;

namespace Promeetec.EDMS.Domain.Models.Menu.MenuItem.Validators;

public class AddMenuItemValidator : AbstractValidator<AddMenuItem>
{
    public AddMenuItemValidator()
    {
       RuleFor(c => c.ParentId)
            .NotEmpty().WithMessage("Parent id is required.");
    }
}
