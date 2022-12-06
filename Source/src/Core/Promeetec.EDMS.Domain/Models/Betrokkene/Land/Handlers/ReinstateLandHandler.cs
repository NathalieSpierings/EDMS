using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land.Events;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Land.Handlers;

public class ReinstateLandHandler : ICommandHandler<ReinstateLand>
{
    private readonly ILandRepository _repository;
    private readonly IEventRepository _eventRepository;

    public ReinstateLandHandler(ILandRepository repository, IEventRepository eventRepository)
    {
        _repository = repository;
        _eventRepository = eventRepository;
    }

    public async Task<IEnumerable<IEvent>> Handle(ReinstateLand command)
    {
        var land = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id && x.Status != Status.Verwijderd);
        if (land == null)
            throw new DataException($"Land met Id {command.Id} niet gevonden.");


        land.Reinstate();

        var @event = new LandGeactiveerd
        {
            TargetId = land.Id,
            TargetType = nameof(Land),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId
        };

        await _repository.UpdateAsync(land);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}