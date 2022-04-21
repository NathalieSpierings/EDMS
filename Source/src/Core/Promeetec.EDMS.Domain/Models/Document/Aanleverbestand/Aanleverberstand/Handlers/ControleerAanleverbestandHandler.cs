using Promeetec.EDMS.Domain.Document.Aanleverbestand.Aanleverberstand.Commands;

namespace Promeetec.EDMS.Domain.Document.Aanleverbestand.Aanleverberstand.Handlers
{
    public class ControleerAanleverbestandHandler : ICommandHandlerAsync<ControleerAanleverbestand>
    {
        private readonly IAanleverbestandRepository _repository;

        public ControleerAanleverbestandHandler(IAanleverbestandRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(ControleerAanleverbestand command)
        {
            var voorraadbestand = await _repository.GetByIdAsync(command.AggregateRootId);
            if (voorraadbestand == null)
                throw new ApplicationException($"Voorraadbestand niet gevonden. Id: {command.AggregateRootId}");

            voorraadbestand.Controleer(command);
            await _repository.UpdateAsync(voorraadbestand);

            return new CommandResponse
            {
                Events = voorraadbestand.Events
            };
        }
    }
}
