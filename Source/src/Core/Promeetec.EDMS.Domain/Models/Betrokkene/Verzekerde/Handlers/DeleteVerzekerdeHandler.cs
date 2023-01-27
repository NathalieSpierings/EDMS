using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde.Handlers
{
    public class DeleteVerzekerdeHandler : ICommandHandler<DeleteVerzekerde>
    {
        private readonly IVerzekerdeRepository _repository;

        public DeleteVerzekerdeHandler(IVerzekerdeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<IEvent>> Handle(DeleteVerzekerde command)
        {
            var verzekerde = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id);
            if (verzekerde == null)
                throw new DataException($"Verzekerde met Id {command.Id} niet gevonden.");

            verzekerde.Delete();
            await _repository.UpdateAsync(verzekerde);

            return new IEvent[] { };
        }
    }
}