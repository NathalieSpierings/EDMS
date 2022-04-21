﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Events;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Events;
using System.Data;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Handlers;

public class UpdateOrganisatieHandler : ICommandHandler<UpdateOrganisatie>
{
    private readonly IOrganisatieRepository _repository;
    private readonly IEventRepository _eventRepository;
    private readonly IValidator<UpdateOrganisatie> _validator;

    public UpdateOrganisatieHandler(IOrganisatieRepository repository, IEventRepository eventRepository, IValidator<UpdateOrganisatie> validator)
    {
        _repository = repository;
        _eventRepository = eventRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(UpdateOrganisatie command)
    {
        await _validator.ValidateCommand(command);

        var organisatie = await _repository.Query()
            .FirstOrDefaultAsync(x => x.Id == command.UpdateOrganisatieId);

        if (organisatie == null)
            throw new DataException($"Organisatie met Id {command.UpdateOrganisatieId} niet gevonden.");

        organisatie.Update(command);

        var @event = new OrganisatieGewijzigd
        {
            TargetId = organisatie.Id,
            TargetType = nameof(Organisatie),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,

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

        await _repository.UpdateAsync(organisatie);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}