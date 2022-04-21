using Promeetec.EDMS.Domain.Modules.Declaratie.Aanleverbericht.Commands;

namespace Promeetec.EDMS.Domain.Modules.Declaratie.Aanleverbericht.Handlers
{
    public class OpenAanleverberichtHandler : ICommandHandlerAsync<OpenAanleverbericht>
    {
        private readonly IAanleverberichtRepository _repository;

        public OpenAanleverberichtHandler(IAanleverberichtRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(OpenAanleverbericht command)
        {
            var bericht = await _repository.GetByIdAsync(command.AggregateRootId);
            if (bericht == null)
                throw new ApplicationException($"Aanleverbericht niet gevonden. Id: {command.AggregateRootId}");

            bericht.Open(command);
            await _repository.UpdateAsync(bericht);

            return new CommandResponse
            {
                Events = bericht.Events
            };
        }
    }
}