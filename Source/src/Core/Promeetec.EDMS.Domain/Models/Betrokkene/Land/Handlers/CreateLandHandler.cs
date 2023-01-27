using FluentValidation;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Land.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Land.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Land.Handlers;

public class CreateLandHandler : ICommandHandler<CreateLand>
{
    private readonly ILandRepository _repository;
    private readonly IEventRepository _eventRepository;
    private readonly IValidator<CreateLand> _validator;

    public CreateLandHandler(ILandRepository repository, 
        IEventRepository eventRepository, 
        IValidator<CreateLand> validator)
    {
        _repository = repository;
        _eventRepository = eventRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(CreateLand command)
    {
        await _validator.ValidateCommand(command);

        var land = new Land(command);

        var @event = new LandAangemaakt
        {
            TargetId = land.Id,
            TargetType = nameof(Land),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            Status = Status.Actief.ToString(),
            CultureCode = command.CultureCode,
            NativeName = command.NativeName
        };

        await _repository.AddAsync(land);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}