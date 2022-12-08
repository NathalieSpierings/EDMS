﻿using FluentValidation;
using Promeetec.EDMS.Domain.Models.Document.Overigbestand.Commands;

namespace Promeetec.EDMS.Domain.Models.Document.Overigbestand.Validators;

public class CreateOverigbestandValidator : AbstractValidator<CreateOverigbestand>
{
    public CreateOverigbestandValidator()
    {
        RuleFor(c => c.FileName)
            .NotEmpty().WithMessage("Bestandsnaam is verplicht.")
            .Length(450).WithMessage("Bestandsnaam kan maximaal 450 tekens lang zijn.");

        RuleFor(c => c.EigenaarId)
            .NotEmpty().WithMessage("Eigenaar is verplicht.");
    }
}
