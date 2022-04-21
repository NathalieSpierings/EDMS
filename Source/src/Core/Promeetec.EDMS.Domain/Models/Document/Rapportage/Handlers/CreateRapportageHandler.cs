using Promeetec.EDMS.Domain.Document.Rapportage.Commands;

namespace Promeetec.EDMS.Domain.Document.Rapportage.Handlers
{
    public class CreateRapportageHandler : ICommandHandlerAsync<NieuweRapportage>
    {
        private readonly IRapportageRepository _repository;

        public CreateRapportageHandler(IRapportageRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(NieuweRapportage command)
        {
            var rapportage = new Rapportage(command);
            await _repository.AddAsync(rapportage);

            return new CommandResponse
            {
                Events = rapportage.Events
            };
        }
    }
}