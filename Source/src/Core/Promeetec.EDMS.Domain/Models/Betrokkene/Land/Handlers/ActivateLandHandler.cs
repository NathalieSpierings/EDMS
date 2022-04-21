using Promeetec.EDMS.Domain.Betrokkene.Land.Commands;

namespace Promeetec.EDMS.Domain.Betrokkene.Land.Handlers;

public class ActivateLandHandler : ICommandHandlerAsync<ActivateLand>
{
    private readonly ILandRepository _repository;

    public ActivateLandHandler(ILandRepository repository)
    {
        _repository = repository;
    }

    public async Task<CommandResponse> HandleAsync(ActivateLand command)
    {
        var land = await _repository.GetByIdAsync(command.AggregateRootId);
        if (land == null)
            throw new ApplicationException($"Land niet gevonden. Id: {command.AggregateRootId}");

        land.Activate(command);
        await _repository.UpdateAsync(land);

        return new CommandResponse
        {
            Events = land.Events
        };
    }
}