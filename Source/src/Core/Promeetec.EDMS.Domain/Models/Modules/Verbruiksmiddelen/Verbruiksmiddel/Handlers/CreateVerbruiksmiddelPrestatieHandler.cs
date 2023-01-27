using FluentValidation;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Core.Extensions;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Handlers;

public class CreateVerbruiksmiddelPrestatieHandler : ICommandHandler<CreateVerbruiksmiddelPrestatie>
{
    private readonly IVerbruiksmiddelPrestatieRepository _repository;
    private readonly IEventRepository _eventRepository;
    private readonly IValidator<CreateVerbruiksmiddelPrestatie> _validator;

    public CreateVerbruiksmiddelPrestatieHandler(IVerbruiksmiddelPrestatieRepository repository,
        IEventRepository eventRepository,
        IValidator<CreateVerbruiksmiddelPrestatie> validator)
    {
        _repository = repository;
        _eventRepository = eventRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(CreateVerbruiksmiddelPrestatie command)
    {
        await _validator.ValidateCommand(command);

        var prestatie = new VerbruiksmiddelPrestatie(command);

        var @event = new VerbruiksmiddelPrestatieAangemaakt
        {
            TargetId = prestatie.Id,
            TargetType = nameof(VerbruiksmiddelPrestatie),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            AgbCodeOnderneming = command.AgbCodeOnderneming,
            HulpmiddelenSoort = command.HulpmiddelenSoort.GetDisplayName(),
            Status = command.Status.ToString(),
            VerwerkJaar = command.VerwerkJaar?.ToString(),
            VerwerkMaand = command.VerwerkMaand?.ToString(),
            ProfielCode = command.ProfielCode?.ToString(),
            ProfielStartdatum = command.ProfielStartdatum.HasValue
                ? command.ProfielStartdatum.Value.ToString("dd-MM-yyyy")
                : string.Empty,
            ProfielEinddatum = command.ProfielStartdatum.HasValue
                ? command.ProfielStartdatum.Value.ToString("dd-MM-yyyy")
                : string.Empty,
            ZIndex = command.ZIndex?.ToString(),
            PrestatieDatum = command.PrestatieDatum.HasValue
                ? command.PrestatieDatum.Value.ToString("dd-MM-yyyy")
                : string.Empty,
            Hoeveelheid = command.Hoeveelheid?.ToString(),
            EigenaarVolledigeNaam = command.EigenaarVolledigeNaam,
            VerzekerdeVolledigeNaam = command.VerzekerdeVolledigeNaam,
            OrganisatieDisplayName = command.OrganisatieDisplayName,
            EigenaarId = command.EigenaarId,
            VerzekerdeId = command.VerzekerdeId
        };

        await _repository.AddAsync(prestatie);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}