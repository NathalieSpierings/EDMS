using FluentValidation;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Commands;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Events;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Handlers
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
				Zorgstraat = bestand.Zorgstraat.Naam,
				Eigenaar = bestand.Eigenaar.Persoon.VolledigeNaam,
				EiStandaardCode = bestand.EiStandaard.Code,
				EiStandaardNaam = bestand.EiStandaard.Naam,
				ZorgstraatId = bestand.ZorgstraatId,
				EiStandaardId = bestand.EiStandaardId,
				AanleveringId = bestand.AanleveringId,
				EigenaarId = bestand.EigenaarId,
			};

			await _repository.AddAsync(bestand);
			await _eventRepository.AddAsync(@event.ToDbEntity());

			return new IEvent[] { @event };
		}
	}
}
