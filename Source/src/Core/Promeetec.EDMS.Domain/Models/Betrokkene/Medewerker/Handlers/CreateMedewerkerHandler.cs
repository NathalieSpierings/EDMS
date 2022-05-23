using FluentValidation;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Events;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Events;
using Promeetec.EDMS.Extensions;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Handlers;

public class CreateMedewerkerHandler : ICommandHandler<CreateMedewerker>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMedewerkerRepository _repository;
    private readonly IValidator<CreateMedewerker> _validator;

    public CreateMedewerkerHandler(IMedewerkerRepository repository,
        IEventRepository eventRepository,
        IValidator<CreateMedewerker> validator)
    {
        _repository = repository;
        _eventRepository = eventRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(CreateMedewerker command)
    {
        await _validator.ValidateCommand(command);

        var medewerker = new Medewerker(command);

        var @event = new MedewerkerAangemaakt
        {
            TargetId = medewerker.Id,
            TargetType = nameof(Medewerker),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,

            Organisatie = command.OrganisatieDisplayName,
            Status = medewerker.Status.ToString(),
            MedewerkerSoort = medewerker.MedewerkerSoort.GetDisplayName(),
            Geslacht = medewerker.Persoon.Geslacht.GetDisplayName(),
            Voorletters = medewerker.Persoon.Voorletters,
            Tussenvoegsel = medewerker.Persoon.Tussenvoegsel,
            Voornaam = medewerker.Persoon.Voornaam,
            Achternaam = medewerker.Persoon.Achternaam,
            VollledigeNaam = medewerker.Persoon.VolledigeNaam,
            Gebruikersnaam = medewerker.UserName,
            Functie = medewerker.Functie,
            TelefoonZakelijk = medewerker.Persoon.TelefoonZakelijk,
            TelefoonPrive = medewerker.Persoon.TelefoonPrive,
            Doorkiesnummer = medewerker.Persoon.Doorkiesnummer,
            Email = medewerker.Email,
            AgbCodeZorgverlener = !string.IsNullOrWhiteSpace(medewerker.AgbCodeZorgverlener) ? string.Concat("[", medewerker.AgbCodeZorgverlener.Replace(",", "]-["), "]") : "",
            AgbCodeOnderneming = !string.IsNullOrWhiteSpace(medewerker.AgbCodeOnderneming) ? string.Concat("[", medewerker.AgbCodeOnderneming.Replace(",", "]-["), "]") : "",
            IonToestemmingsverklaringActivatieLink = medewerker.IONToestemmingsverklaringActivatieLink,
            Adres = medewerker.Adres?.VolledigAdres,
        };

        await _repository.AddAsync(medewerker);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}
