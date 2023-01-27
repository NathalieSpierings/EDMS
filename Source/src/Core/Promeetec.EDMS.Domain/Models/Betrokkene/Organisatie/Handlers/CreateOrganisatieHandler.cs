using FluentValidation;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Event;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie.Handlers;

public class CreateOrganisatieHandler : ICommandHandler<CreateOrganisatie>
{
    private readonly IOrganisatieRepository _repository;
    private readonly IEventRepository _eventRepository;
    private readonly IValidator<CreateOrganisatie> _validator;

    public CreateOrganisatieHandler(IOrganisatieRepository repository,
        IEventRepository eventRepository,
        IValidator<CreateOrganisatie> validator)
    {
        _repository = repository;
        _eventRepository = eventRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(CreateOrganisatie command)
    {
        await _validator.ValidateCommand(command);

        var organisatie = new Organisatie(command);

        var @event = new OrganisatieAangemaakt
        {
            TargetId = organisatie.Id,
            TargetType = nameof(Organisatie),
            OrganisatieId = organisatie.Id,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            Nummer = organisatie.Nummer,
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

        await _repository.AddAsync(organisatie);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}
