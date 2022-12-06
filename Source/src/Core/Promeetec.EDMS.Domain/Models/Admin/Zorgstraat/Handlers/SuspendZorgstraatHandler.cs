using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Admin.Zorgstraat.Commands;
using Promeetec.EDMS.Domain.Models.Admin.Zorgstraat.Events;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Admin.Zorgstraat.Handlers;

public class SuspendZorgstraatHandler : ICommandHandler<SuspendZorgstraat>
{
    private readonly IZorgstraatRepository _repository;
    private readonly IEventRepository _eventRepository;

    public SuspendZorgstraatHandler(IZorgstraatRepository repository, IEventRepository eventRepository)
    {
        _repository = repository;
        _eventRepository = eventRepository;
    }

    public async Task<IEnumerable<IEvent>> Handle(SuspendZorgstraat command)
    {
        var zorgstraat = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id && x.Status != Status.Verwijderd);
        if (zorgstraat == null)
            throw new DataException($"Zorgstraat met Id {command.Id} niet gevonden.");

        zorgstraat.Suspend();

        var @event = new ZorgstraatGedeactiveerd
        {
            TargetId = zorgstraat.Id,
            TargetType = nameof(Zorgstraat),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId
        };

        await _repository.UpdateAsync(zorgstraat);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}