﻿using System.Text.RegularExpressions;
using FluentValidation;
using Promeetec.EDMS.Portaal.Core;
using Promeetec.EDMS.Portaal.Domain.Models.Menu.Menu.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Menu.Menu.Validators.Rules;

namespace Promeetec.EDMS.Portaal.Domain.Models.Menu.Menu.Validators;

public class CreateMenuValidator : AbstractValidator<CreateMenu>
{
    public CreateMenuValidator(IDispatcher dispatcher)
    {
        RuleFor(c => c.Id)
            .NotEmpty().WithMessage("Id is verplicht.")
            .MustAsync((c, p, cancellation) => dispatcher.Get(new IsMenuIdUnique { Id = c.Id }))
            .WithMessage(c => $"Er bestaat al een menu met id {c.Id}.");

        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Naam is verplicht.")
            .Length(3, 200).WithMessage("Naam kan maximaal 200 tekens lang zijn.")
            .Must(BeValidName)
            .WithMessage(c => "Naam is niet geldig. Alleen letters, nummers, underscores and liggende streepjes zijn geldig.")
            .MustAsync((c, p, cancellation) => dispatcher.Get(new IsMenuNameUnique { Name = c.Name }))
            .WithMessage(c => $"Er bestaat al een menu met naam {c.Name}.");

        RuleFor(c => c.MenuType)
            .IsInEnum().WithMessage("Soort is verplicht.");
    }

    private bool BeValidName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return false;

        var regex = new Regex(@"^[A-Za-z\d\s_-]+$");
        var match = regex.Match(name);

        return match.Success;
    }
}
