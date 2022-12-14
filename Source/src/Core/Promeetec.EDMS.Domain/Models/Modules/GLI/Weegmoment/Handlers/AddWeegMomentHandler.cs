using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Models.Modules.GLI.Weegmoment.Commands;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Modules.GLI.Weegmoment.Handlers;

public class AddWeegMomentHandler : ICommandHandler<CreateWeegmoment>
{
    private readonly IWeegMomentRepository _repository;

    public AddWeegMomentHandler(IWeegMomentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<IEvent>> Handle(CreateWeegmoment command)
    {
        var weegmoment = new Weegmoment(command);
        await _repository.AddAsync(weegmoment);

        return new IEvent[] { };
    }
}