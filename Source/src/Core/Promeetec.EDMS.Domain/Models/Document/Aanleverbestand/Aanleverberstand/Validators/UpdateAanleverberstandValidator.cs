using FluentValidation;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Validators;

public class UpdateAanleverbestandValidator : AbstractValidator<UpdateAanleverbestand>
{
	public UpdateAanleverbestandValidator()
	{
		RuleFor(c => c.EigenaarId)
			.NotEmpty().WithMessage("Eigenaar is verplicht.");
	}
}
