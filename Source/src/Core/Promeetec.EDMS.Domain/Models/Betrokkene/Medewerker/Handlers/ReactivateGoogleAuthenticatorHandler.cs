using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Core.Extensions;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Users;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker.Handlers;


public class ReactivateGoogleAuthenticatorHandler : ICommandHandler<ReactivateGoogleAuthenticator>
{
    private readonly IMedewerkerRepository _repository;
    private readonly IEventRepository _eventRepository;

    public ReactivateGoogleAuthenticatorHandler(IMedewerkerRepository repository, IEventRepository eventRepository)
    {
        _repository = repository;
        _eventRepository = eventRepository;
    }

    public async Task<IEnumerable<IEvent>> Handle(ReactivateGoogleAuthenticator command)
    {
        var medewerker = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id && x.Status != Status.Verwijderd);
        if (medewerker == null)
            throw new DataException($"Medewerker met Id {command.Id} niet gevonden.");

        medewerker.ReactivateGoogleAuthenticator(command);

        var @event = new GoogleAuthenticatorGeheractiveerd
        {
            TargetId = medewerker.Id,
            TargetType = nameof(Organisatie.Organisatie),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            GoogleAuthenticatorAan = "Nee",
            GoogleAuthenticatorSecretKey = null,
            TwoFactorAuthentieAan = "Nee",
            AccountStatus = UserAccountState.ReactivateGoogleAuthenticator.GetDisplayName()
        };

        await _repository.UpdateAsync(medewerker);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}

