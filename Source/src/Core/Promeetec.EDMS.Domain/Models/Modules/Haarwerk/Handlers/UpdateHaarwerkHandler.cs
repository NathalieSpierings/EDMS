using System.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Modules.Haarwerk.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Haarwerk.Events;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Modules.Haarwerk.Handlers;

public class UpdateHaarwerkHandler : ICommandHandler<UpdateHaarwerk>
{
    private readonly IHaarwerkRepository _repository;
    private readonly IEventRepository _eventRepository;
    private readonly IValidator<UpdateHaarwerk> _validator;

    public UpdateHaarwerkHandler(IHaarwerkRepository repository, IEventRepository eventRepository, IValidator<UpdateHaarwerk> validator)
    {
        _repository = repository;
        _eventRepository = eventRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(UpdateHaarwerk command)
    {
        await _validator.ValidateCommand(command);

        var haarwerk = await _repository.Query()
            .FirstOrDefaultAsync(x => x.Id == command.Id);

        if (haarwerk == null)
            throw new DataException($"Haarwerk registratie met Id {command.Id} niet gevonden.");

        haarwerk.Update(command);

        var @event = new HaarwerkGewijzigd
        {
            TargetId = haarwerk.Id,
            TargetType = nameof(Haarwerk),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,

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
