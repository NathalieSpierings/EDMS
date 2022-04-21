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

public class UnRestrictOrganisatieHandler : ICommandHandler<UnrestrictOrganisatie>
{
    private readonly IOrganisatieRepository _repository;
    private readonly IEventRepository _eventRepository;

    public UnRestrictOrganisatieHandler(IOrganisatieRepository repository, IEventRepository eventRepository)
    {
        _repository = repository;
        _eventRepository = eventRepository;
    }

    public async Task<IEnumerable<IEvent>> Handle(UnrestrictOrganisatie command)
    {
        var organisatie = await _repository.Query()
            .FirstOrDefaultAsync(x =>
                x.Id == command.UnrestrictOrganisatieId &&
                x.Status != Status.Verwijderd);

        if (organisatie == null)
            throw new DataException($"Organisatie met Id {command.UnrestrictOrganisatieId} niet gevonden.");

        organisatie.Unrestrict();
        await _repository.UpdateAsync(organisatie);

        var @event = new OrganisatieGedeblokkeerd
        {
            TargetId = organisatie.Id,
            TargetType = nameof(Organisatie),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId
        };

        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}
