using System.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Document.Bestand.Commands;
using Promeetec.EDMS.Domain.Models.Document.Bestand.Events;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Document.Bestand.Handlers
{
	public class UpdateBestandHandler : ICommandHandler<UpdateBestand>
	{
		private readonly IBestandRepository _repository;
		private readonly IEventRepository _eventRepository;
		private readonly IValidator<UpdateBestand> _validator;


		public UpdateBestandHandler(IBestandRepository repository,
			IEventRepository eventRepository,
			IValidator<UpdateBestand> validator)
		{
			_repository = repository;
			_eventRepository = eventRepository;
			_validator = validator;
		}

		public async Task<IEnumerable<IEvent>> Handle(UpdateBestand command)
		{
			await _validator.ValidateCommand(command);

			var bestand = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id);
			if (bestand == null)
				throw new DataException($"Bestand met Id {command.Id} niet gevonden.");

			bestand.Update(command);

			var @event = new BestandGewijzigd
			{
				TargetId = bestand.Id,
				TargetType = nameof(Bestand),
				OrganisatieId = command.OrganisatieId,
				UserId = command.UserId,
				UserDisplayName = command.UserDisplayName,

				Bestandsnaam = bestand.FileName,
				EigenaarId = bestand.EigenaarId
			};

			await _repository.UpdateAsync(bestand);
			await _eventRepository.AddAsync(@event.ToDbEntity());

			return new IEvent[] { @event };
		}
	}
}
