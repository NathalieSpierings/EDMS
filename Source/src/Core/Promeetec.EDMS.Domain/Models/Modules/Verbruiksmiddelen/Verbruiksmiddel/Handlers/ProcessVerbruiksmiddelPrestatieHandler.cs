using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Handlers;

public class ProcessVerbruiksmiddelPrestatieHandler : ICommandHandler<ProcessVerbruiksmiddelPrestatie>
{
    private readonly IVerbruiksmiddelPrestatieRepository _repository;
    private readonly IEventRepository _eventRepository;

    public ProcessVerbruiksmiddelPrestatieHandler(IVerbruiksmiddelPrestatieRepository repository,
        IEventRepository eventRepository)
    {
        _repository = repository;
        _eventRepository = eventRepository;
    }

    public async Task<IEnumerable<IEvent>> Handle(ProcessVerbruiksmiddelPrestatie command)
    {
        var prestatie = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id && x.Status != VerbruiksmiddelPrestatieStatus.Verwerkt);
        if (prestatie == null)
            throw new DataException($"Prestatie met Id {command.Id} niet gevonden.");

        prestatie.Process();

        var @event = new VerbruiksmiddelPrestatieVerwerkt
        {
            TargetId = prestatie.Id,
            TargetType = nameof(VerbruiksmiddelPrestatie),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            Status = command.Status.ToString()
        };

        await _repository.UpdateAsync(prestatie);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}