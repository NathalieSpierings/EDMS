using FluentValidation;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Bestand.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Document.Bestand.Validators;

public class UpdateEigenaarBestandValidator : AbstractValidator<UpdateEigenaarBestand>
{
	public UpdateEigenaarBestandValidator()
	{
		RuleFor(c => c.EigenaarId)
			.NotEmpty().WithMessage("Eigenaar is verplicht.");
	}
}
