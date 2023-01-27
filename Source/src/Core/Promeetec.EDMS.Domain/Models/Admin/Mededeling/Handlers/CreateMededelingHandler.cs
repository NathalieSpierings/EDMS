using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.Mededeling.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Admin.Mededeling.Handlers;

public class CreateMededelingHandler : ICommandHandler<CreateMededeling>
{
    private readonly IMededelingRepository _repository;
    public CreateMededelingHandler(IMededelingRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<IEvent>> Handle(CreateMededeling command)
    {
        var country = new Mededeling(command);

        await _repository.AddAsync(country);

        return new IEvent[] { };
    }
}