using Promeetec.EDMS.Domain.Betrokkene.Verzekerde.Commands;

namespace Promeetec.EDMS.Domain.Betrokkene.Verzekerde.Handlers
{
    public class DeactivateVerzekerdeMetZorgprofielHandler : ICommandHandlerAsync<DeactiveerVerzekerdeMetZorgprofiel>
    {
        private readonly IVerzekerdeRepository _repository;

        public DeactivateVerzekerdeMetZorgprofielHandler(IVerzekerdeRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(DeactiveerVerzekerdeMetZorgprofiel command)
        {
            var verzekerde = await _repository.GetByIdAsync(command.AggregateRootId);
            if (verzekerde == null)
                throw new ApplicationException($"Verzekerde niet gevonden. Id: {command.AggregateRootId}");

            var laatsteEindatum = _repository.GetLaatsteZorgprofielEinddatum(verzekerde.Id);
            if (laatsteEindatum >= command.ProfielEinddatum)
                command.ProfielEinddatum = laatsteEindatum.AddDays(1);

            verzekerde.DeactivateMetZorgprofiel(command);
            await _repository.UpdateAsync(verzekerde);

            return new CommandResponse
            {
                Events = verzekerde.Events
            };
        }
    }
}