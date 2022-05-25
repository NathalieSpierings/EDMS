using FluentValidation;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Betrokkene.Memo.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Memo.Events;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Memo.Handlers;

public class CreateMemoHandler : ICommandHandler<CreateMemo>
{
    private readonly IMemoRepository _repository;
    private readonly IEventRepository _eventRepository;
    private readonly IValidator<CreateMemo> _validator;


    public CreateMemoHandler(IMemoRepository repository, IEventRepository eventRepository, IValidator<CreateMemo> validator)
    {
        _repository = repository;
        _eventRepository = eventRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(CreateMemo command)
    {
        await _validator.ValidateCommand(command);

        var memo = new Memo(command);

        var @event = new MemoAangemaakt
        {
            TargetId = memo.Id,
            TargetType = nameof(Memo),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,

            Datum = command.Date.ToString("dd-MM-yyyy"),
            Memo = command.Content
        };

        await _repository.AddAsync(memo);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}