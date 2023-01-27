using FluentValidation;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekeraar.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekeraar.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Event;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekeraar.Handlers;

public class CreateVerzekeraarHandler : ICommandHandler<CreateVerzekeraar>
{
    private readonly IVerzekeraarRepository _repository;
    private readonly IEventRepository _eventRepository;
    private readonly IValidator<CreateVerzekeraar> _validator;


    public CreateVerzekeraarHandler(IVerzekeraarRepository repository, IEventRepository eventRepository, IValidator<CreateVerzekeraar> validator)
    {
        _repository = repository;
        _eventRepository = eventRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(CreateVerzekeraar command)
    {
        await _validator.ValidateCommand(command);

        var memo = new Verzekeraar(command);

        var @event = new VerzekeraarAangemaakt
        {
            TargetId = memo.Id,
            TargetType = nameof(Memo.Memo),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            Uzovi = command.Uzovi.ToString(),
            Naam = command.Naam,
            Actief = command.Actief ? "Ja" : "Nee"
        };

        await _repository.AddAsync(memo);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}