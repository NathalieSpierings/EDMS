using FluentValidation;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Events;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Events;
using Promeetec.EDMS.Extensions;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Handlers
{
	public class CreateVerzekerdeHandler : ICommandHandler<CreateVerzekerde>
	{
		private readonly IVerzekerdeRepository _repository;
		private readonly IEventRepository _eventRepository;
		private readonly IValidator<CreateVerzekerde> _validator;

		public CreateVerzekerdeHandler(IVerzekerdeRepository repository, IEventRepository eventRepository, IValidator<CreateVerzekerde> validator)
		{
			_repository = repository;
			_eventRepository = eventRepository;
			_validator = validator;
		}

		public async Task<IEnumerable<IEvent>> Handle(CreateVerzekerde command)
		{
			await _validator.ValidateCommand(command);

			var verzekerde = new Verzekerde(command);

			verzekerde.Users.Add(new VerzekerdeToUser
			{
				VerzekerdeId = command.Id,
				UserId = command.UserId
			});

			var @event = new VerzekerdeAangemaakt
			{
				TargetId = verzekerde.Id,
				TargetType = nameof(Verzekerde),
				OrganisatieId = command.OrganisatieId,
				UserId = command.UserId,
				UserDisplayName = command.UserDisplayName,

				Status = verzekerde.Status.ToString(),
				Bsn = verzekerde.Bsn,
				Lengte = verzekerde.Lengte.ToString(),
				Geslacht = verzekerde.Persoon.Geslacht?.GetDisplayName(),
				Geboortedatum = verzekerde.Persoon.Geboortedatum?.ToString("dd-MM-yyyy"),
				VolledigeNaam = verzekerde.Persoon.VolledigeNaam,
				VolledigAdres = verzekerde.Adres.VolledigAdres,
				AgbCodeVerwijzer = verzekerde.AgbCodeVerwijzer,
				NaamVerwijzer = verzekerde.NaamVerwijzer,
				Verwijsdatum = verzekerde.Verwijsdatum?.ToString("dd-MM-yyyy"),
				PatientNummer = verzekerde.Zorgverzekering.PatientNummer,
				VerzekerdeNummer = verzekerde.Zorgverzekering.VerzekerdeNummer,
				VerzekerdOp = verzekerde.Zorgverzekering.VerzekerdOp.ToString("dd-MM-yyyy"),
				VerzekerdTot = verzekerde.Zorgverzekering.VerzekerdTot?.ToString("dd-MM-yyyy"),
				Uzovi = verzekerde.Zorgverzekering.Verzekeraar.Uzovi.ToString(),
				VerzekeraarNaam = verzekerde.Zorgverzekering.Verzekeraar.Naam,
				ProfielCode = verzekerde.Zorgprofiel.ProfielCode.ToString(),
				ProfielStartdatum = verzekerde.Zorgprofiel.ProfielStartdatum.ToString("dd-MM-yyyy"),
				ProfielEinddatum = verzekerde.Zorgprofiel.ProfielEinddatum?.ToString("dd-MM-yyyy"),
			};

			await _repository.AddAsync(verzekerde);
			await _eventRepository.AddAsync(@event.ToDbEntity());

			return new IEvent[] { @event };
		}
	}
}