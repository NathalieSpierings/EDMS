using System.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Bestand.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Bestand.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Event;

namespace Promeetec.EDMS.Portaal.Domain.Models.Document.Bestand.Handlers
{
	public class UpdateEigenaarBestandHandler : ICommandHandler<UpdateEigenaarBestand>
	{
		private readonly IBestandRepository _repository;
		private readonly IEventRepository _eventRepository;
		private readonly IValidator<UpdateEigenaarBestand> _validator;


		public UpdateEigenaarBestandHandler(IBestandRepository repository,
			IEventRepository eventRepository,
			IValidator<UpdateEigenaarBestand> validator)
		{
			_repository = repository;
			_eventRepository = eventRepository;
			_validator = validator;
		}

		public async Task<IEnumerable<IEvent>> Handle(UpdateEigenaarBestand command)
		{
			await _validator.ValidateCommand(command);

			var bestand = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id);
			if (bestand == null)
				throw new DataException($"Bestand met Id {command.Id} niet gevonden.");

			bestand.UpdateEigenaar(command);

			var @event = new EigenaarBestandGewijzigd
			{
				TargetId = bestand.Id,
				TargetType = nameof(Bestand),
				OrganisatieId = command.OrganisatieId,
				UserId = command.UserId,
				UserDisplayName = command.UserDisplayName,

				EigenaarId = bestand.EigenaarId,
				Eigenaar = bestand.Eigenaar.Persoon.VolledigeNaam
			};

			await _repository.UpdateAsync(bestand);
			await _eventRepository.AddAsync(@event.ToDbEntity());

			return new IEvent[] { @event };
		}
	}
}
