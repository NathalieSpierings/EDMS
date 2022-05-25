using FluentValidation;
using Promeetec.EDMS.Domain.Models.Betrokkene.Memo.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Memo.Validators;

public class CreateMemoValidator : AbstractValidator<CreateMemo>
{
    public CreateMemoValidator()
    {
        RuleFor(c => c.Content)
            .NotEmpty().WithMessage("Content is verplicht.");
    }
}
