﻿using FluentValidation;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Events;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Handlers;

public class CreateOrganisatieHandler : ICommandHandler<CreateOrganisatie>
{
    private readonly IEventRepository _eventRepository;
    private readonly IOrganisatieRepository _repository;
    private readonly IValidator<CreateOrganisatie> _validator;

    public CreateOrganisatieHandler(IOrganisatieRepository repository,
        IEventRepository eventRepository,
        IValidator<CreateOrganisatie> validator)
    {
        _repository = repository;
        _eventRepository = eventRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(CreateOrganisatie command)
    {
        await _validator.ValidateCommand(command);

        var organisatie = new Organisatie(command);

        var @event = new OrganisatieAangemaakt
        {
            TargetId = organisatie.Id,
            TargetType = nameof(Organisatie),
            OrganisatieId = organisatie.Id,
            UserId = command.UserId,

            Nummer = organisatie.Nummer,
            Naam = organisatie.Naam,
            TelefoonZakelijk = organisatie.TelefoonZakelijk,
            TelefoonPrive = organisatie.TelefoonPrive,
            Email = organisatie.Email,
            Website = organisatie.Website,
            AgbCodeOnderneming = organisatie.AgbCodeOnderneming,
            Zorggroep = organisatie.Zorggroep,
            IONZoekoptie = organisatie.Settings.IONZoekoptie,
            AanleverbestandLocatie = organisatie.Settings.AanleverbestandLocatie,
            AanleverStatusNaSchrijvenAanleverbestanden = organisatie.Settings.AanleverStatusNaSchrijvenAanleverbestanden,
            COVControleType = organisatie.Settings.COVControleType,
            COVControleProcessType = organisatie.Settings.COVControleProcessType,
            VerwijzerInAdresboek = organisatie.Settings.VerwijzerInAdresboek
        };

        await _repository.AddAsync(organisatie);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}