using System.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Core.Extensions;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Adres;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker.Handlers;

public class UpdateMedewerkerHandler : ICommandHandler<UpdateMedewerker>
{
    private readonly IMedewerkerRepository _repository;
    private readonly IAdresRepository _adresRepository;

    private readonly IEventRepository _eventRepository;
    private readonly IValidator<UpdateMedewerker> _validator;

    public UpdateMedewerkerHandler(IMedewerkerRepository repository,
        IAdresRepository adresRepository,
        IEventRepository eventRepository,
        IValidator<UpdateMedewerker> validator)
    {
        _repository = repository;
        _adresRepository = adresRepository;
        _eventRepository = eventRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(UpdateMedewerker command)
    {
        await _validator.ValidateCommand(command);

        var medewerker = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id && x.Status != Status.Verwijderd);
        if (medewerker == null)
            throw new DataException($"Medewerker met Id {command.Id} niet gevonden.");

        var currentAdres = medewerker.Adres;
        if (currentAdres != null && command.Adres == null)
            await _adresRepository.RemoveAsync(currentAdres);

        medewerker.Update(command);

        var @event = new MedewerkerGewijzigd
        {
            TargetId = medewerker.Id,
            TargetType = nameof(Medewerker),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            Geslacht = medewerker.Persoon.Geslacht?.GetDisplayName(),
            Voorletters = medewerker.Persoon.Voorletters,
            Tussenvoegsel = medewerker.Persoon.Tussenvoegsel,
            Voornaam = medewerker.Persoon.Voornaam,
            Achternaam = medewerker.Persoon.Achternaam,
            VollledigeNaam = medewerker.Persoon.VolledigeNaam,
            Functie = medewerker.Functie,
            TelefoonZakelijk = medewerker.Persoon.TelefoonZakelijk,
            TelefoonPrive = medewerker.Persoon.TelefoonPrive,
            Doorkiesnummer = medewerker.Persoon.Doorkiesnummer,
            Email = medewerker.Email,
            AgbCodeZorgverlener = !string.IsNullOrWhiteSpace(medewerker.AgbCodeZorgverlener) ? string.Concat("[", medewerker.AgbCodeZorgverlener.Replace(",", "]-["), "]") : "",
            AgbCodeOnderneming = !string.IsNullOrWhiteSpace(medewerker.AgbCodeOnderneming) ? string.Concat("[", medewerker.AgbCodeOnderneming.Replace(",", "]-["), "]") : "",
            Adres = medewerker.Adres.VolledigAdres,
        };

        await _repository.UpdateAsync(medewerker);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}
