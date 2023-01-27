using FluentValidation;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Event;

namespace Promeetec.EDMS.Portaal.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Handlers
{
	public class CreateAanleverbestandHandler : ICommandHandler<CreateAanleverbestand>
	{
		private readonly IAanleverbestandRepository _repository;
		private readonly IEventRepository _eventRepository;
		private readonly IValidator<CreateAanleverbestand> _validator;


		public CreateAanleverbestandHandler(IAanleverbestandRepository repository,
			IEventRepository eventRepository,
			IValidator<CreateAanleverbestand> validator)
		{
			_repository = repository;
			_eventRepository = eventRepository;
			_validator = validator;
		}

		public async Task<IEnumerable<IEvent>> Handle(CreateAanleverbestand command)
		{
			await _validator.ValidateCommand(command);

			var bestand = new Aanleverbestand(command);

			var @event = new AanleverbestandAangemaakt
			{
				TargetId = bestand.Id,
				TargetType = nameof(Bestand),
				OrganisatieId = command.OrganisatieId,
				UserId = command.UserId,
				UserDisplayName = command.UserDisplayName,

				Bestandsnaam = bestand.FileName,
				Bestandsgrootte = bestand.FileSize,
				Periode = bestand.Periode,

                EiStandaardId = bestand.EiStandaardId,
                EiStandaardCode = command.EiStandaardCode,
				EiStandaardNaam = command.EiStandaardNaam,

				ZorgstraatId = bestand.ZorgstraatId,
                Zorgstraat = command.ZorgstraatNaam,

                AanleveringId = bestand.AanleveringId,
				EigenaarId = bestand.EigenaarId,
                Eigenaar = command.EigenaarVolledigeNaam,
            };

			await _repository.AddAsync(bestand);
			await _eventRepository.AddAsync(@event.ToDbEntity());

			return new IEvent[] { @event };
		}
	}
}
