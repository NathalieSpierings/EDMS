using Promeetec.EDMS.Domain.Betrokkene.Verzekerde.Commands;

namespace Promeetec.EDMS.Domain.Betrokkene.Verzekerde.Handlers
{
    public class ActivateVerzekerdeMetZorgprofielHandler : ICommandHandlerAsync<ActiveerVerzekerdeMetZorgprofiel>
    {
        private readonly IVerzekerdeRepository _repository;

        public ActivateVerzekerdeMetZorgprofielHandler(IVerzekerdeRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(ActiveerVerzekerdeMetZorgprofiel command)
        {
            var verzekerde = await _repository.GetByIdAsync(command.AggregateRootId);
            if (verzekerde == null)
                throw new ApplicationException($"Verzekerde niet gevonden. Id: {command.AggregateRootId}");


            // Controleer het verleden of de opgegeven startdatum niet de vorige startdatum overschrijft.
            var laatsteStartdatum = _repository.GetLaatsteZorgprofielStartdatum(verzekerde.Id);
            if (laatsteStartdatum >= command.ProfielStartdatum)
                command.ProfielStartdatum = laatsteStartdatum.AddDays(1);

            verzekerde.ActivateMetZorgprofiel(command);
            await _repository.UpdateAsync(verzekerde);

            return new CommandResponse
            {
                Events = verzekerde.Events
            };
        }
    }
}