using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Events;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Handlers;

public class ReinstateMedewerkerHandler : ICommandHandler<ReinstateMedewerker>
{
	private readonly IMedewerkerRepository _repository;
	private readonly IEventRepository _eventRepository;

	public ReinstateMedewerkerHandler(IMedewerkerRepository repository, IEventRepository eventRepository)
	{
		_repository = repository;
		_eventRepository = eventRepository;
	}

	public async Task<IEnumerable<IEvent>> Handle(ReinstateMedewerker command)
	{
		var medewerker = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id && x.Status != Status.Verwijderd);
		if (medewerker == null)
			throw new DataException($"Medewerker met Id {command.Id} niet gevonden.");

		medewerker.Reinstate();

		var @event = new MedewerkerGeactiveerd
		{
			TargetId = medewerker.Id,
			TargetType = nameof(Medewerker),
			OrganisatieId = command.OrganisatieId,
			UserId = command.UserId,
			UserDisplayName = command.UserDisplayName,

			Status = Status.Actief.ToString()
		};

		await _repository.UpdateAsync(medewerker);
		await _eventRepository.AddAsync(@event.ToDbEntity());

		return new IEvent[] { @event };
	}
}
