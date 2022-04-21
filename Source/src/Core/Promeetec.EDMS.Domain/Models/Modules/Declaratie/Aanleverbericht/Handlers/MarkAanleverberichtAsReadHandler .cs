using Promeetec.EDMS.Domain.Modules.Declaratie.Aanleverbericht.Commands;

namespace Promeetec.EDMS.Domain.Modules.Declaratie.Aanleverbericht.Handlers
{
    public class MarkAanleverberichtAsReadedHandler : ICommandHandlerAsync<MarkAanleverberichtAsRead>
    {
        private readonly IAanleverberichtRepository _repository;

        public MarkAanleverberichtAsReadedHandler(IAanleverberichtRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(MarkAanleverberichtAsRead command)
        {
            var aanleverbericht = await _repository.GetByIdAsync(command.AggregateRootId);
            if (aanleverbericht == null)
                throw new ApplicationException($"Aanleverbericht niet gevonden. Id: {command.AggregateRootId}");

            aanleverbericht.MarkAsRead(command);
            await _repository.UpdateAsync(aanleverbericht);

            return new CommandResponse
            {
                Events = aanleverbericht.Events
            };
        }
    }
}