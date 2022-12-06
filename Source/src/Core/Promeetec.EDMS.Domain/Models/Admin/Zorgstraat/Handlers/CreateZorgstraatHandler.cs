using FluentValidation;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Admin.Zorgstraat.Commands;
using Promeetec.EDMS.Domain.Models.Admin.Zorgstraat.Events;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Admin.Zorgstraat.Handlers;

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

            Naam = command.Naam,
            Status = Status.Actief.ToString()
        };

        await _repository.AddAsync(zorgstraat);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}
