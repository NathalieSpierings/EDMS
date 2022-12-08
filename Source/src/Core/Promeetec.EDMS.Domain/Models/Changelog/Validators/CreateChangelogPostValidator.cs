﻿using FluentValidation;
using Promeetec.EDMS.Domain.Models.Changelog.Commands;

namespace Promeetec.EDMS.Domain.Models.Changelog.Validators;

public class CreateChangelogPostValidator : AbstractValidator<CreateChangelogPost>
{
    public CreateChangelogPostValidator()
    {
        RuleFor(c => c.Title)
            .NotEmpty().WithMessage("Title is verplicht.")
            .Length(200).WithMessage("Title kan maximaal 200 tekens lang zijn.");

        RuleFor(c => c.Description)
            .NotEmpty().WithMessage("Description is verplicht.")
            .Length(450).WithMessage("Description kan maximaal 450 tekens lang zijn.");

        RuleFor(c => c.Content)
            .NotEmpty().WithMessage("Content is verplicht.");
    }
}