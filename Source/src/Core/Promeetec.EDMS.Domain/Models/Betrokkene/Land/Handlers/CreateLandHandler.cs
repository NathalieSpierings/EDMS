using Promeetec.EDMS.Domain.Betrokkene.Land.Commands;

namespace Promeetec.EDMS.Domain.Betrokkene.Land.Handlers;

public class CreateLandHandler : ICommandHandlerAsync<CreateLand>
{
    private readonly ILandRepository _repository;

    public CreateLandHandler(ILandRepository repository)
    {
        _repository = repository;
    }

    public async Task<CommandResponse> HandleAsync(CreateLand command)
    {
        var land = new Land(command);
        await _repository.AddAsync(land);

        return new CommandResponse
        {
            Events = land.Events
        };
    }
}