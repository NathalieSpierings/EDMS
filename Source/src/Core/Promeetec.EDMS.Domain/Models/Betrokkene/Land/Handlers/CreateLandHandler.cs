using FluentValidation;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land.Events;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Land.Handlers;

public class CreateLandHandler : ICommandHandler<CreateLand>
{
    private readonly ILandRepository _repository;
    private readonly IEventRepository _eventRepository;
    private readonly IValidator<CreateLand> _validator;

    public CreateLandHandler(ILandRepository repository, IEventRepository eventRepository, IValidator<CreateLand> validator)
    {
        _repository = repository;
        _eventRepository = eventRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(CreateLand command)
    {
        await _validator.ValidateCommand(command);

        var country = new Land(command);

        var @event = new LandAangemaakt
        {
            TargetId = country.Id,
            TargetType = nameof(Land),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,

            Status = Status.Actief.ToString(),
            CultureCode = command.CultureCode,
            NativeName = command.NativeName
        };

        await _repository.AddAsync(country);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}