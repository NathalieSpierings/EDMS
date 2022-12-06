using FluentValidation;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Modules.Haarwerk.Events;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Modules.Haarwerk.Handlers;

public class CreateHaarwerkHandler : ICommandHandler<CreateHaarwerk>
{
    private readonly IEventRepository _eventRepository;
    private readonly IHaarwerkRepository _repository;
    private readonly IValidator<CreateOrganisatie> _validator;

    public CreateHaarwerkHandler(IHaarwerkRepository repository,
        IEventRepository eventRepository,
        IValidator<CreateHaarwerk> validator)
    {
        _repository = repository;
        _eventRepository = eventRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(CreateHaarwerk command)
    {
        await _validator.ValidateCommand(command);

        var organisatie = new Haarwerk(command);

        var @event = new HaarwerkAangemaakt
        {
            TargetId = organisatie.Id,
            TargetType = nameof(Haarwerk),
            OrganisatieId = organisatie.Id,
            UserId = command.UserId,

            //Nummer = organisatie.Nummer,
            //Naam = organisatie.Naam,
            //TelefoonZakelijk = organisatie.TelefoonZakelijk,
            //TelefoonPrive = organisatie.TelefoonPrive,
            //Email = organisatie.Email,
            //Website = organisatie.Website,
            //AgbCodeOnderneming = organisatie.AgbCodeOnderneming,
            //Zorggroep = organisatie.Zorggroep,
            //AanleverbestandLocatie = organisatie.Settings.AanleverbestandLocatie,
            //AanleverStatusNaSchrijvenAanleverbestanden = organisatie.Settings.AanleverStatusNaSchrijvenAanleverbestanden,
            //VerwijzerInAdresboek = organisatie.Settings.VerwijzerInAdresboek
        };

        await _repository.AddAsync(organisatie);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}
