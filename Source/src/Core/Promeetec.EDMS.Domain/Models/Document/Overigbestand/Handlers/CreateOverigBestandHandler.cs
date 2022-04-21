using Promeetec.EDMS.Domain.Document.Overigbestand.Commands;

namespace Promeetec.EDMS.Domain.Document.Overigbestand.Handlers
{
    public class CreateOverigbestandHandler : ICommandHandlerAsync<NieuwOverigbestand>
    {
        private readonly IOverigbestandRepository _repository;

        public CreateOverigbestandHandler(IOverigbestandRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(NieuwOverigbestand command)
        {
            var overigBestand = new Overigbestand(command);
            await _repository.AddAsync(overigBestand);

            return new CommandResponse
            {
                Events = overigBestand.Events
            };
        }
    }
}
