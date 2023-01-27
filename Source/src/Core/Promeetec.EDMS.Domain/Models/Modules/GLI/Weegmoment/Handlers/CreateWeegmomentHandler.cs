using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Weegmoment.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Weegmoment.Handlers;

public class CreateWeegmomentHandler : ICommandHandler<CreateWeegmoment>
{
    private readonly IWeegmomentRepository _repository;

    public CreateWeegmomentHandler(IWeegmomentRepository repository)
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