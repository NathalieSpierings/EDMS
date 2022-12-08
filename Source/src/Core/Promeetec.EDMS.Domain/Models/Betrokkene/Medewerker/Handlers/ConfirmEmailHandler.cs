using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Events;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Identity.Users;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Events;
using Promeetec.EDMS.Extensions;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Handlers;

public class ConfirmEmailHandler : ICommandHandler<ConfirmEmail>
{
    private readonly IMedewerkerRepository _repository;
    private readonly IEventRepository _eventRepository;

    public ConfirmEmailHandler(IMedewerkerRepository repository,
        IEventRepository eventRepository)
    {
        _repository = repository;
        _eventRepository = eventRepository;
    }

    public async Task<IEnumerable<IEvent>> Handle(ConfirmEmail command)
    {
        var medewerker = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id && x.Status != Status.Verwijderd);
        if (medewerker == null)
            throw new DataException($"Medewerker met Id {command.Id} niet gevonden.");

        medewerker.ConfirmEmail();

        var @event = new EmailBevestigd
        {
            TargetId = medewerker.Id,
            TargetType = nameof(Medewerker),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            EmailIsBevestigd = "Ja",
            AccountState = UserAccountState.EmailConfirmed.GetDisplayName(),
        };

        await _repository.UpdateAsync(medewerker);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}
