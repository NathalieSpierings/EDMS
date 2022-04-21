using Promeetec.EDMS.Domain.Document.Bestand.Commands;

namespace Promeetec.EDMS.Domain.Document.Bestand.Handlers
{
    public class WijzigEigenaarBestandHandler : ICommandHandlerAsync<WijzigEigenaarBestand>
    {
        private readonly IBestandRepository _repository;

        public WijzigEigenaarBestandHandler(IBestandRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(WijzigEigenaarBestand command)
        {
            var bestand = await _repository.GetByIdAsync(command.AggregateRootId);
            if (bestand == null)
                throw new ApplicationException($"Bestand niet gevonden. Id: {command.AggregateRootId}");

            bestand.WijzigEigenaar(command);
            await _repository.UpdateAsync(bestand);

            return new CommandResponse
            {
                Events = bestand.Events
            };
        }
    }
}