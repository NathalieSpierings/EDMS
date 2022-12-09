using FluentValidation;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Document.Overigbestand.Commands;
using Promeetec.EDMS.Domain.Models.Document.Overigbestand.Events;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Document.Overigbestand.Handlers
{
	public class CreateOverigBestandHandler : ICommandHandler<CreateOverigBestand>
	{
		private readonly IOverigBestandRepository _repository;
		private readonly IEventRepository _eventRepository;
		private readonly IValidator<CreateOverigBestand> _validator;


		public CreateOverigBestandHandler(IOverigBestandRepository repository, IEventRepository eventRepository, IValidator<CreateOverigBestand> validator)
		{
			_repository = repository;
			_eventRepository = eventRepository;
			_validator = validator;
		}

		public async Task<IEnumerable<IEvent>> Handle(CreateOverigBestand command)
		{
			await _validator.ValidateCommand(command);

			var bestand = new Overigbestand(command);

			var @event = new OverigbestandAangemaakt
			{
				TargetId = bestand.Id,
				TargetType = nameof(Bestand),
				OrganisatieId = command.OrganisatieId,
				UserId = command.UserId,
				UserDisplayName = command.UserDisplayName,

				Bestandsnaam = bestand.FileName,
				Bestandsgrootte = bestand.FileSize,
				AanleveringId = bestand.AanleveringId,
                ReferentiePromeetec = command.ReferentiePromeetec,

                EigenaarId = bestand.EigenaarId,
                Eigenaar = command.EigenaarVolledigeNaam

            };

			await _repository.AddAsync(bestand);
			await _eventRepository.AddAsync(@event.ToDbEntity());

			return new IEvent[] { @event };
		}
	}
}
