using System.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Event;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie.Handlers;

public class UpdateOrganisatieHandler : ICommandHandler<UpdateOrganisatie>
{
	private readonly IOrganisatieRepository _repository;
	private readonly IEventRepository _eventRepository;
	private readonly IValidator<UpdateOrganisatie> _validator;

	public UpdateOrganisatieHandler(IOrganisatieRepository repository,
		IEventRepository eventRepository,
		IValidator<UpdateOrganisatie> validator)
	{
		_repository = repository;
		_eventRepository = eventRepository;
		_validator = validator;
	}

	public async Task<IEnumerable<IEvent>> Handle(UpdateOrganisatie command)
	{
		await _validator.ValidateCommand(command);

		var organisatie = await _repository.Query()
			.FirstOrDefaultAsync(x => x.Id == command.Id);

		if (organisatie == null)
			throw new DataException($"Organisatie met Id {command.Id} niet gevonden.");

		organisatie.Update(command);

		var @event = new OrganisatieGewijzigd
		{
			TargetId = organisatie.Id,
			TargetType = nameof(Organisatie),
			OrganisatieId = command.OrganisatieId,
			UserId = command.UserId,
			UserDisplayName = command.UserDisplayName,

			Naam = organisatie.Naam,
			TelefoonZakelijk = organisatie.TelefoonZakelijk,
			TelefoonPrive = organisatie.TelefoonPrive,
			Email = organisatie.Email,
			Website = organisatie.Website,
			AgbCodeOnderneming = organisatie.AgbCodeOnderneming,
			Zorggroep = organisatie.Zorggroep,
			AanleverbestandLocatie = organisatie.Settings.AanleverbestandLocatie,
			AanleverStatusNaSchrijvenAanleverbestanden = organisatie.Settings.AanleverStatusNaSchrijvenAanleverbestanden,
			VerwijzerInAdresboek = organisatie.Settings.VerwijzerInAdresboek
		};

		await _repository.UpdateAsync(organisatie);
		await _eventRepository.AddAsync(@event.ToDbEntity());

		return new IEvent[] { @event };
	}
}
