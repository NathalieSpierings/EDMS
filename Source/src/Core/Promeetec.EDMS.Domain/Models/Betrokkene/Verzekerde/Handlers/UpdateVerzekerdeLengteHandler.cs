using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde.Handlers
{
    public class UpdateVerzekerdeLengteHandler : ICommandHandler<UpdateVerzekerdeLength>
    {
        private readonly IVerzekerdeRepository _repository;

        public UpdateVerzekerdeLengteHandler(IVerzekerdeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<IEvent>> Handle(UpdateVerzekerdeLength command)
        {
            var verzekerde = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id);
            if (verzekerde == null)
                throw new DataException($"Verzekerde met Id {command.Id} niet gevonden.");

            verzekerde.UpdateLength(command.Lengte);
            await _repository.UpdateAsync(verzekerde);

            return new IEvent[] { };
        }
    }
}