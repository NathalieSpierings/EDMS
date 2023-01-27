using FluentValidation;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Core.Extensions;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Rapportage.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Rapportage.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Event;

namespace Promeetec.EDMS.Portaal.Domain.Models.Document.Rapportage.Handlers
{
	public class CreateRapportageHandler : ICommandHandler<CreateRapportage>
	{
		private readonly IRapportageRepository _repository;
		private readonly IEventRepository _eventRepository;
		private readonly IValidator<CreateRapportage> _validator;

		public CreateRapportageHandler(IRapportageRepository repository, IEventRepository eventRepository, IValidator<CreateRapportage> validator)
		{
			_repository = repository;
			_eventRepository = eventRepository;
			_validator = validator;
		}

		public async Task<IEnumerable<IEvent>> Handle(CreateRapportage command)
		{
			await _validator.ValidateCommand(command);


			var bestand = new Rapportage(command);

			var @event = new RapportageAangemaakt
			{
				TargetId = bestand.Id,
				TargetType = nameof(Rapportage),
				OrganisatieId = command.OrganisatieId,
				UserId = command.UserId,
				UserDisplayName = command.UserDisplayName,

				Bestandsnaam = bestand.FileName,
				Bestandsgrootte = bestand.FileSize,
				ReferentiePromeetec = command.Referentie,
				Organisatie = command.OrganisatieDisplayName,
				RapportageSoort = bestand.RapportageSoort.GetDisplayName(),
				EigenaarId = bestand.EigenaarId,
				Eigenaar = command.EigenaarVolledigeNaam,
			};

			await _repository.AddAsync(bestand);
			await _eventRepository.AddAsync(@event.ToDbEntity());

			return new IEvent[] { @event };
		}
	}
}