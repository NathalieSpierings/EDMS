using Promeetec.EDMS.Domain.Document.Bestand.Commands;

namespace Promeetec.EDMS.Domain.Document.Bestand.Handlers
{
    public class CreateBestandHandler : ICommandHandlerAsync<NieuwBestand>
    {
        private readonly IBestandRepository _repository;

        public CreateBestandHandler(IBestandRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(NieuwBestand command)
        {
            var bestand = new Bestand(command);
            await _repository.AddAsync(bestand);

            return new CommandResponse
            {
                Events = bestand.Events
            };
        }
    }
}
