using FluentValidation;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Modules.Haarwerk.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Haarwerk.Events;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Modules.Haarwerk.Handlers;

public class CreateHaarwerkHandler : ICommandHandler<CreateHaarwerk>
{
    private readonly IEventRepository _eventRepository;
    private readonly IHaarwerkRepository _repository;
    private readonly IValidator<CreateHaarwerk> _validator;

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

        var haarwerk = new Haarwerk(command);

        var @event = new HaarwerkAangemaakt
        {
            TargetId = haarwerk.Id,
            TargetType = nameof(Haarwerk),
            OrganisatieId = haarwerk.OrganisatieId,
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

        await _repository.AddAsync(haarwerk);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}
