﻿using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land.Events;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Land.Handlers;

public class SuspendCountryHandler : ICommandHandler<SuspendCountry>
{
    private readonly ILandRepository _repository;
    private readonly IEventRepository _eventRepository;

    public SuspendCountryHandler(ILandRepository repository, IEventRepository eventRepository)
    {
        _repository = repository;
        _eventRepository = eventRepository;
    }

    public async Task<IEnumerable<IEvent>> Handle(SuspendCountry command)
    {
        var country = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id && x.Status != Status.Verwijderd);
        if (country == null)
            throw new DataException($"Land met Id {command.Id} niet gevonden.");

        country.Suspend();

        var @event = new LandGedeactiveerd
        {
            TargetId = country.Id,
            TargetType = nameof(Land),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId
        };

        await _repository.UpdateAsync(country);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}