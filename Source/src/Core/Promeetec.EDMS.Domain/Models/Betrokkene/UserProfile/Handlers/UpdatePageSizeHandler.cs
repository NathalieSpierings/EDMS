using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.UserProfile.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.UserProfile.Handlers
{
    public class UpdatePageSizeHandler : ICommandHandler<UpdatePageSize>
    {
        private readonly IUserProfileRepository _repository;

        public UpdatePageSizeHandler(IUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<IEvent>> Handle(UpdatePageSize command)
        {
            var profile = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id);
            if (profile == null)
                throw new DataException($"Profiel met Id {command.Id} niet gevonden.");

            profile.UpdatePageSize(command);
            await _repository.UpdateAsync(profile);

            return new IEvent[] { };
        }
    }
}