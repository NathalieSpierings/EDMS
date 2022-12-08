using FluentValidation;
using Promeetec.EDMS.Domain.Models.Document.Bestand.Commands;

namespace Promeetec.EDMS.Domain.Models.Document.Bestand.Validators;

public class UpdateBestandValidator : AbstractValidator<UpdateBestand>
{
	public UpdateBestandValidator()
	{
		RuleFor(c => c.FileName)
			.NotEmpty().WithMessage("Bestandsnaam is verplicht.")
			.Length(450).WithMessage("Bestandsnaam kan maximaal 450 tekens lang zijn.");
	}
}
