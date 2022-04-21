using Promeetec.EDMS.Domain.Modules.Declaratie.Aanlevering.Commands;

namespace Promeetec.EDMS.Domain.Modules.Declaratie.Aanlevering.Handlers
{
    public class CreateAanleveringHandler : ICommandHandlerAsync<CreateAanlevering>
    {
        private readonly IAanleveringRepository _repository;

        public CreateAanleveringHandler(IAanleveringRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(CreateAanlevering command)
        {
            var aanlevering = new Aanlevering(command);
            await _repository.AddAsync(aanlevering);

            return new CommandResponse
            {
                Events = aanlevering.Events
            };
        }
    }
}
