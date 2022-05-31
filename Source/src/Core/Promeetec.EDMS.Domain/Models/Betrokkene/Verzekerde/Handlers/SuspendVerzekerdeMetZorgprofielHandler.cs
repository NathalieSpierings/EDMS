using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Commands;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Handlers
{
    public class SuspendVerzekerdeMetZorgprofielHandler : ICommandHandler<SuspendVerzekerdeMetZorgprofiel>
    {
        private readonly IVerzekerdeRepository _repository;

        public SuspendVerzekerdeMetZorgprofielHandler(IVerzekerdeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<IEvent>> Handle(SuspendVerzekerdeMetZorgprofiel command)
        {
            var verzekerde = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id);
            if (verzekerde == null)
                throw new DataException($"Verzekerde met Id {command.Id} niet gevonden.");


            var laatsteEindatum = _repository.GetLaatsteZorgprofielEinddatum(verzekerde.Id);
            if (laatsteEindatum >= command.ProfielEinddatum)
                command.ProfielEinddatum = laatsteEindatum.AddDays(1);

            verzekerde.SuspendWithProfile(command);
            await _repository.UpdateAsync(verzekerde);

            return new IEvent[] {  };
        }
    }
}