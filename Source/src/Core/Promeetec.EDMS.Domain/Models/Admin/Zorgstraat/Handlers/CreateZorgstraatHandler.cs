using Promeetec.EDMS.Domain.Admin.Zorgstraat.Commands;

namespace Promeetec.EDMS.Domain.Admin.Zorgstraat.Handlers;

public class CreateZorgstraatHandler : ICommandHandlerAsync<CreateZorgstraat>
{
    private readonly IZorgstraatRepository _repository;

    public CreateZorgstraatHandler(IZorgstraatRepository repository)
    {
        _repository = repository;
    }

    public async Task<CommandResponse> HandleAsync(CreateZorgstraat command)
    {
        var zorgstraat = new Zorgstraat(command);
        await _repository.AddAsync(zorgstraat);

        return new CommandResponse
        {
            Events = zorgstraat.Events
        };
    }
}