using Promeetec.EDMS.Domain.Document.Aanleverbestand.Aanleverberstand.Commands;

namespace Promeetec.EDMS.Domain.Document.Aanleverbestand.Aanleverberstand.Handlers
{
    public class CreateAanleverbestandHandler : ICommandHandlerAsync<NieuwAanleverbestand>
    {
        private readonly IAanleverbestandRepository _repository;

        public CreateAanleverbestandHandler(IAanleverbestandRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(NieuwAanleverbestand command)
        {
            var aanleverbestand = new Aanleverbestand(command);
            await _repository.AddAsync(aanleverbestand);

            return new CommandResponse
            {
                Events = aanleverbestand.Events
            };
        }
    }
}
