using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Modules.Haarwerk.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Haarwerk.Events;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Modules.Haarwerk.Handlers;

public class CreditHaarwerkHandler : ICommandHandler<CreditHaarwerk>
{
    private readonly IHaarwerkRepository _repository;
    private readonly IEventRepository _eventRepository;

    public CreditHaarwerkHandler(IHaarwerkRepository repository, IEventRepository eventRepository)
    {
        _repository = repository;
        _eventRepository = eventRepository;
    }

    public async Task<IEnumerable<IEvent>> Handle(CreditHaarwerk command)
    {
        var haarwerk = await _repository.Query()
            .FirstOrDefaultAsync(x => x.Id == command.Id);

        if (haarwerk == null)
            throw new DataException($"Haarwerk registratie met Id {command.Id} niet gevonden.");

        haarwerk.Credit(command);

        var @event = new HaarwerkGecrediteerd
        {
            TargetId = haarwerk.Id,
            TargetType = nameof(Haarwerk),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            Naam = haarwerk.Naam,
            Geboortedatum = haarwerk.Geboortedatum,
            Bsn = haarwerk.Bsn,
            Verzekeringsnummer = haarwerk.Verzekeringsnummer,
            Machtigingsnummer = haarwerk.Machtigingsnummer,
            TypeHulpmiddel = haarwerk.TypeHulpmiddel,
            LeveringSoort = haarwerk.LeveringSoort,
            HaarwerkSoort = haarwerk.HaarwerkSoort,
            Afleverdatum = haarwerk.Afleverdatum,
            DatumVoorgaandHulpmiddel = haarwerk.DatumVoorgaandHulpmiddel,
            DatumMedischVoorschrift = haarwerk.DatumMedischVoorschrift,
            PrijsHaarwerk = haarwerk.PrijsHaarwerk,
            BedragBasisVerzekering = haarwerk.BedragBasisVerzekering,
            BedragAanvullendeVerzekering = haarwerk.BedragAanvullendeVerzekering,
            BedragEigenBijdragen = haarwerk.BedragEigenBijdragen,
            BedragTeOntvangen = haarwerk.BedragTeOntvangen,
            CreditType = haarwerk.CreditType
        };

        await _repository.UpdateAsync(haarwerk);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}
