using Promeetec.EDMS.Domain.Betrokkene.Land.Commands;

namespace Promeetec.EDMS.Domain.Betrokkene.Land.Handlers;

public class DeactivateLandHandler : ICommandHandlerAsync<DeactivateLand>
{
    private readonly ILandRepository _repository;

    public DeactivateLandHandler(ILandRepository repository)
    {
        _repository = repository;
    }

    public async Task<CommandResponse> HandleAsync(DeactivateLand command)
    {
        var land = await _repository.GetByIdAsync(command.AggregateRootId);
        if (land == null)
            throw new ApplicationException($"Land niet gevonden. Id: {command.AggregateRootId}");

        land.Deactivate(command);
        await _repository.UpdateAsync(land);

        return new CommandResponse
        {
            Events = land.Events
        };
    }
}