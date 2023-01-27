using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.Zorgstraat.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.Zorgstraat.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Portaal.Domain.Models.Admin.Zorgstraat.Handlers;

public class DeleteZorgstraatHandler : ICommandHandler<DeleteZorgstraat>
{
    private readonly IZorgstraatRepository _repository;
    private readonly IEventRepository _eventRepository;

    public DeleteZorgstraatHandler(IZorgstraatRepository repository, IEventRepository eventRepository)
    {
        _repository = repository;
        _eventRepository = eventRepository;
    }


    public async Task<IEnumerable<IEvent>> Handle(DeleteZorgstraat command)
    {
        var zorgstraat = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id && x.Status != Status.Verwijderd);
        if (zorgstraat == null)
            throw new DataException($"Zorgstraat met Id {command.Id} niet gevonden.");


        zorgstraat.Delete();

        var @event = new ZorgstraatVerwijderd
        {
            TargetId = zorgstraat.Id,
            TargetType = nameof(Zorgstraat),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            Status = Status.Verwijderd.ToString()
        };

        await _repository.UpdateAsync(zorgstraat);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}