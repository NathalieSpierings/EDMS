using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Events;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Handlers;

public class DeleteOrganisatieHandler : ICommandHandler<DeleteOrganisatie>
{
    private readonly IOrganisatieRepository _repository;
    private readonly IEventRepository _eventRepository;

    public DeleteOrganisatieHandler(IOrganisatieRepository repository, IEventRepository eventRepository)
    {
        _repository = repository;
        _eventRepository = eventRepository;
    }

    public async Task<IEnumerable<IEvent>> Handle(DeleteOrganisatie command)
    {
        var organisatie = await _repository.Query()
            .FirstOrDefaultAsync(x =>
                x.Id == command.Id &&
                x.Status != Status.Verwijderd);

        if (organisatie == null)
            throw new DataException($"Organisatie met Id {command.Id} niet gevonden.");


        organisatie.Delete();
        await _repository.UpdateAsync(organisatie);

        var @event = new OrganisatieVerwijderd
        {
            TargetId = organisatie.Id,
            TargetType = nameof(Organisatie),
            OrganisatieId = organisatie.Id,
            UserId = command.UserId
        };

       await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}
