using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Commands;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Handlers
{
    public class ReinstateVerzekerdeMetZorgprofielHandler : ICommandHandler<ReinstateVerzekerdeMetZorgprofiel>
    {
        private readonly IVerzekerdeRepository _repository;

        public ReinstateVerzekerdeMetZorgprofielHandler(IVerzekerdeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<IEvent>> Handle(ReinstateVerzekerdeMetZorgprofiel command)
        {
            var verzekerde = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id);
            if (verzekerde == null)
                throw new DataException($"Verzekerde met Id {command.Id} niet gevonden.");


            // Controleer het verleden of de opgegeven startdatum niet de vorige startdatum overschrijft.
            var laatsteStartdatum = _repository.GetLaatsteZorgprofielStartdatum(verzekerde.Id);
            if (laatsteStartdatum >= command.ProfielStartdatum)
                command.ProfielStartdatum = laatsteStartdatum.AddDays(1);

            verzekerde.ReinstateWithProfile(command);
            await _repository.UpdateAsync(verzekerde);

            return new IEvent[] { };
        }
    }
}