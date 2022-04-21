using Promeetec.EDMS.Domain.Document.Aanleverbestand.Aanleverberstand.Commands;

namespace Promeetec.EDMS.Domain.Document.Aanleverbestand.Aanleverberstand.Handlers
{
    public class OncontroleerAanleverbestandHandler : ICommandHandlerAsync<OnControleerAanleverbestand>
    {
        private readonly IAanleverbestandRepository _repository;

        public OncontroleerAanleverbestandHandler(IAanleverbestandRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(OnControleerAanleverbestand command)
        {
            var voorraadbestand = await _repository.GetByIdAsync(command.AggregateRootId);
            if (voorraadbestand == null)
                throw new ApplicationException($"Voorraadbestand niet gevonden. Id: {command.AggregateRootId}");

            voorraadbestand.OnControleer(command);
            await _repository.UpdateAsync(voorraadbestand);

            return new CommandResponse
            {
                Events = voorraadbestand.Events
            };
        }
    }
}
