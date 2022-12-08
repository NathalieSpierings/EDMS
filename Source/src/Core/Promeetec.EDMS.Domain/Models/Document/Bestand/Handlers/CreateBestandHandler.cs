using FluentValidation;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Document.Bestand.Commands;
using Promeetec.EDMS.Domain.Models.Document.Bestand.Events;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Document.Bestand.Handlers
{
	public class CreateBestandHandler : ICommandHandler<CreateBestand>
	{
		private readonly IBestandRepository _repository;
		private readonly IEventRepository _eventRepository;
		private readonly IValidator<CreateBestand> _validator;


		public CreateBestandHandler(IBestandRepository repository,
		IEventRepository eventRepository,
		IValidator<CreateBestand> validator)
		{
			_repository = repository;
			_eventRepository = eventRepository;
			_validator = validator;
		}

		public async Task<IEnumerable<IEvent>> Handle(CreateBestand command)
		{
			await _validator.ValidateCommand(command);

			var bestand = new Bestand(command);

			var @event = new BestandAangemaakt
			{
				TargetId = bestand.Id,
				TargetType = nameof(Bestand),
				OrganisatieId = command.OrganisatieId,
				UserId = command.UserId,
				UserDisplayName = command.UserDisplayName,

				Bestandsnaam = bestand.FileName,
				Bestandsgrootte = bestand.FileSize,
				Extensie = bestand.Extension,
				MimeType = bestand.MimeType,
				Eigenaar = bestand.Eigenaar.Persoon.VolledigeNaam,
				EigenaarId = bestand.EigenaarId,
			};

			await _repository.AddAsync(bestand);
			await _eventRepository.AddAsync(@event.ToDbEntity());

			return new IEvent[] { @event };
		}
	}
}
