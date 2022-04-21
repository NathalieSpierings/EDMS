using Promeetec.EDMS.Domain.Modules.Declaratie.Aanlevering.Commands;

namespace Promeetec.EDMS.Domain.Modules.Declaratie.Aanlevering.Handlers
{
    public class DeleteAanleveringHandler : ICommandHandlerAsync<DeleteAanlevering>
    {
        private readonly IAanleveringRepository _repository;

        public DeleteAanleveringHandler(IAanleveringRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(DeleteAanlevering command)
        {
            var aanlevering = await _repository.GetByIdAsync(command.AggregateRootId);
            if (aanlevering == null)
                throw new ApplicationException($"Aanlevering niet gevonden. Id: {command.AggregateRootId}");

            aanlevering.Delete(command);
            await _repository.UpdateAsync(aanlevering);

            return new CommandResponse
            {
                Events = aanlevering.Events
            };
        }
    }
}
