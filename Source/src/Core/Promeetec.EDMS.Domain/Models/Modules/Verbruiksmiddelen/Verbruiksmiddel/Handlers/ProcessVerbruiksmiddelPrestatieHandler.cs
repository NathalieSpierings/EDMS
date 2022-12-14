using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Events;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Handlers;

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