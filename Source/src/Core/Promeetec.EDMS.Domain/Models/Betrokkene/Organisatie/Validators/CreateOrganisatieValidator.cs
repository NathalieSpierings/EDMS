﻿using FluentValidation;
using Promeetec.EDMS.Portaal.Core;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie.Validators.Rules;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie.Validators;

public class CreateOrganisatieValidator : AbstractValidator<CreateOrganisatie>
{
    public CreateOrganisatieValidator(IDispatcher dispatcher)
    {
        RuleFor(c => c.Nummer)
            .NotEmpty().WithMessage("Nummer is verplicht.")
            .MaximumLength(20).WithMessage("Nummer kan maximaal 20 tekens lang zijn.")
            .MustAsync((c, p, cancellation) => dispatcher.Get(new IsOrganisatieNummerUnique { Nummer = p, Id = c.Id }))
            .WithMessage(c => $"Er bestaat al een organisatie met nummer {c.Nummer}.");


        RuleFor(c => c.Naam)
           .NotEmpty().WithMessage("Naam is verplicht.")
           .MaximumLength(200).WithMessage("Naam kan maximaal 200 tekens lang zijn.");

        RuleFor(c => c.AgbCodeOnderneming)
            .NotEmpty().WithMessage("AGB-code onderneming is verplicht.");

        RuleFor(c => c.TelefoonZakelijk)
            .Length(10, 15).WithMessage("Telefoonnummer zakelijk moet minimaal 10 cijfers bevatten en mag niet langer zijn dan 15 cijfers.");

        RuleFor(c => c.TelefoonPrive)
            .Length(10, 15).WithMessage("Telefoonnummer privé moet minimaal 10 cijfers bevatten en mag niet langer zijn dan 15 cijfers.");

        RuleFor(c => c.Email)
            .MaximumLength(450).WithMessage("E-mail kan maximaal 450 tekens lang zijn.")
            .EmailAddress().WithMessage("Dit is geen geldig e-mailadres!");

        RuleFor(c => c.Website)
            .MaximumLength(256).WithMessage("Website kan maximaal 256 tekens lang zijn.")
            .Must(BeAValidUrl).WithMessage("Dit is geen geldige website URL. HTTP://www.xx.nl");

        RuleFor(c => c.ContactpersoonId)
            .NotEmpty().WithMessage("Contactpersoon is verplicht.");
    }

    private static bool BeAValidUrl(string arg)
    {
        return Uri.TryCreate(arg, UriKind.Absolute, out var result);
    }
}
