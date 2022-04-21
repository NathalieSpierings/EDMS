﻿using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Events;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Handlers;


public class RestrictOrganisatieHandler : ICommandHandler<RestrictOrganisatie>
{
    private readonly IOrganisatieRepository _repository;
    private readonly IEventRepository _eventRepository;

    public RestrictOrganisatieHandler(IOrganisatieRepository repository, IEventRepository eventRepository)
    {
        _repository = repository;
        _eventRepository = eventRepository;
    }

    public async Task<IEnumerable<IEvent>> Handle(RestrictOrganisatie command)
    {
        var organisatie = await _repository.Query()
            .FirstOrDefaultAsync(x =>
                x.Id == command.RestrictOrganisatieId &&
                x.Status != Status.Verwijderd);

        if (organisatie == null)
            throw new DataException($"Organisatie met Id {command.RestrictOrganisatieId} niet gevonden.");

        organisatie.Restrict(command.Reason);
        await _repository.UpdateAsync(organisatie);

        var @event = new OrganisatieGeblokkeerd
        {
            TargetId = organisatie.Id,
            TargetType = nameof(Organisatie),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,

            RedeBlokkade = command.Reason
        };

        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}
