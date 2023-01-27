using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde.Handlers
{
    public class ReinstateVerzekerdeMetZorgprofielHandler : ICommandHandler<ReinstateVerzekerdeMetZorgprofiel>
    {
        private readonly IVerzekerdeRepository _repository;
        private readonly IEventRepository _eventRepository;

        public ReinstateVerzekerdeMetZorgprofielHandler(IVerzekerdeRepository repository, IEventRepository eventRepository)
        {
            _repository = repository;
            _eventRepository = eventRepository;
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

            var @event = new VerzekerdeMetZorgprofielGeactiveerd
            {
                TargetId = verzekerde.Id,
                TargetType = nameof(Verzekerde),
                OrganisatieId = command.OrganisatieId,
                UserId = command.UserId,
                UserDisplayName = command.UserDisplayName,

                Status = Status.Actief.ToString(),
                ProfielCode = verzekerde.Zorgprofiel.ProfielCode.ToString(),
                ProfielStartdatum = verzekerde.Zorgprofiel.ProfielStartdatum.ToString("dd-MM-yyyy"),
                ProfielEinddatum = verzekerde.Zorgprofiel.ProfielEinddatum.HasValue
                    ? verzekerde.Zorgprofiel.ProfielEinddatum.Value.ToString("dd-MM-yyyy")
                    : string.Empty
            };

            await _repository.UpdateAsync(verzekerde);
            await _eventRepository.AddAsync(@event.ToDbEntity());

            return new IEvent[] { @event };
        }
    }
}