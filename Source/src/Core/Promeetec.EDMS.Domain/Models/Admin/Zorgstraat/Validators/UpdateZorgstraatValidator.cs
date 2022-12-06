﻿using FluentValidation;
using Promeetec.EDMS.Domain.Models.Admin.Zorgstraat.Commands;

namespace Promeetec.EDMS.Domain.Models.Admin.Zorgstraat.Validators;

public class UpdateZorgstraatValidator : AbstractValidator<UpdateZorgstraat>
{
    public UpdateZorgstraatValidator()
    {
        RuleFor(c => c.Naam)
            .NotEmpty().WithMessage("Naam is verplicht.")
            .Length(200).WithMessage("Naam kan maximaal 200 tekens lang zijn.");
    }
}
