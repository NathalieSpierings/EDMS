using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Commands;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Events;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Handlers
{
	public class UpdateAanleverbestandHandler : ICommandHandler<UpdateAanleverbestand>
	{
		private readonly IAanleverbestandRepository _repository;
		private readonly IEventRepository _eventRepository;
		private readonly IValidator<UpdateAanleverbestand> _validator;


		public UpdateAanleverbestandHandler(IAanleverbestandRepository repository,
			IEventRepository eventRepository,
			IValidator<UpdateAanleverbestand> validator)
		{
			_repository = repository;
			_eventRepository = eventRepository;
			_validator = validator;
		}

		public async Task<IEnumerable<IEvent>> Handle(UpdateAanleverbestand command)
		{
			await _validator.ValidateCommand(command);

			var aanleverbestand = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id);
			if (aanleverbestand == null)
				throw new ApplicationException($"Aanleverbestand met Id {command.Id} niet gevonden.");

			aanleverbestand.Update(command);

			var @event = new AanleverbestandGewijzigd
			{
				TargetId = aanleverbestand.Id,
				TargetType = nameof(Bestand.Bestand),
				OrganisatieId = command.OrganisatieId,
				UserId = command.UserId,
				UserDisplayName = command.UserDisplayName,

				Periode = aanleverbestand.Periode,
				Zorgstraat = command.ZorgstraatNaam,
				ZorgstraatId = aanleverbestand.ZorgstraatId,

				EigenaarId = aanleverbestand.EigenaarId,
                Eigenaar = command.EigenaarVolledigeNaam,

            };

			await _repository.UpdateAsync(aanleverbestand);
			await _eventRepository.AddAsync(@event.ToDbEntity());

			return new IEvent[] { @event };
		}
	}
}
