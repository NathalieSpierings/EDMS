using Promeetec.EDMS.Domain.Modules.GLI.Behandelplan.Commands;

namespace Promeetec.EDMS.Domain.Modules.GLI.Behandelplan.Handlers
{
    public class StartBehandeltrajectHandler : ICommandHandlerAsync<StartBehandeltraject>
    {
        private readonly IGliBehandelplanRepository _repository;

        public StartBehandeltrajectHandler(IGliBehandelplanRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(StartBehandeltraject command)
        {
            var behandelplan = new GliBehandelplan(command);
            await _repository.AddAsync(behandelplan);

            return new CommandResponse
            {
                Events = behandelplan.Events
            };
        }
    }
}