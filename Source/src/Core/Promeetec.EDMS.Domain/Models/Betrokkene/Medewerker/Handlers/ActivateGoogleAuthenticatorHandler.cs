﻿using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Core.Extensions;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker.Handlers;


public class ActivateGoogleAuthenticatorHandler : ICommandHandler<ActivateGoogleAuthenticator>
{
    private readonly IMedewerkerRepository _repository;
    private readonly IEventRepository _eventRepository;

    public ActivateGoogleAuthenticatorHandler(IMedewerkerRepository repository, IEventRepository eventRepository)
    {
        _repository = repository;
        _eventRepository = eventRepository;
    }

    public async Task<IEnumerable<IEvent>> Handle(ActivateGoogleAuthenticator command)
    {
        var medewerker = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id && x.Status != Status.Verwijderd);
        if (medewerker == null)
            throw new DataException($"Medewerker met Id {command.Id} niet gevonden.");

        medewerker.ActivateGoogleAuthenticator(command);

        var @event = new GoogleAuthenticatorGeactiveerd
        {
            TargetId = medewerker.Id,
            TargetType = nameof(Organisatie.Organisatie),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,

            GoogleAuthenticatorAan = "Ja",
            AccountStatus = command.AccountState.GetDisplayName(),
            GoogleAuthenticatorSecretKey = command.SecretKey
        };

        await _repository.UpdateAsync(medewerker);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}

