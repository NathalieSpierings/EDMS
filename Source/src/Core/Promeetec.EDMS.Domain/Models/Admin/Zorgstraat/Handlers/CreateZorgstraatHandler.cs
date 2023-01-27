using FluentValidation;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.Zorgstraat.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.Zorgstraat.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Portaal.Domain.Models.Admin.Zorgstraat.Handlers;

public class CreateZorgstraatHandler : ICommandHandler<CreateZorgstraat>
{
    private readonly IZorgstraatRepository _repository;
    private readonly IEventRepository _eventRepository;
    private readonly IValidator<CreateZorgstraat> _validator;

    public CreateZorgstraatHandler(IZorgstraatRepository repository,
        IEventRepository eventRepository,
        IValidator<CreateZorgstraat> validator)
    {
        _repository = repository;
        _eventRepository = eventRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(CreateZorgstraat command)
    {
        await _validator.ValidateCommand(command);

        var zorgstraat = new Zorgstraat(command);

        var @event = new ZorgstraatAangemaakt
        {
            TargetId = zorgstraat.Id,
            TargetType = nameof(Zorgstraat),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            Naam = command.Naam,
            Status = Status.Actief.ToString()
        };

        await _repository.AddAsync(zorgstraat);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}
