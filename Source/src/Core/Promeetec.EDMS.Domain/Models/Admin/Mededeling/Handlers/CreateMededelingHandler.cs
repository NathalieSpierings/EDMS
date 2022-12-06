using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Models.Admin.Mededeling.Commands;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Admin.Mededeling.Handlers;

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