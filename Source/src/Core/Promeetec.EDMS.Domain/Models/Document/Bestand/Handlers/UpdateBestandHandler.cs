using Promeetec.EDMS.Domain.Document.Bestand.Commands;

namespace Promeetec.EDMS.Domain.Document.Bestand.Handlers
{
    public class UpdateBestandHandler : ICommandHandlerAsync<WijzigBestand>
    {
        private readonly IBestandRepository _repository;
        public UpdateBestandHandler(IBestandRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(WijzigBestand command)
        {
            var bestand = await _repository.GetByIdAsync(command.AggregateRootId);
            if (bestand == null)
                throw new ApplicationException($"Bestand niet gevonden. Id: {command.AggregateRootId}");

            bestand.Update(command);
            await _repository.UpdateAsync(bestand);

            return new CommandResponse
            {
                Events = bestand.Events
            };
        }
    }
}
