using Promeetec.EDMS.Domain.Betrokkene.Verzekerde.Commands;

namespace Promeetec.EDMS.Domain.Betrokkene.Verzekerde.Handlers
{
    public class DeactivateVerzekerdeHandler : ICommandHandlerAsync<DeactiveerVerzekerde>
    {
        private readonly IVerzekerdeRepository _repository;

        public DeactivateVerzekerdeHandler(IVerzekerdeRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(DeactiveerVerzekerde command)
        {
            var verzekerde = await _repository.GetByIdAsync(command.AggregateRootId);
            if (verzekerde == null)
                throw new ApplicationException($"Verzekerde niet gevonden. Id: {command.AggregateRootId}");

            verzekerde.Deactivate(command);
            await _repository.UpdateAsync(verzekerde);

            return new CommandResponse
            {
                Events = verzekerde.Events
            };
        }
    }
}