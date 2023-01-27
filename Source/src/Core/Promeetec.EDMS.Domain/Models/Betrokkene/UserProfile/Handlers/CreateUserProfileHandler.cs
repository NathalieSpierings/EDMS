using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.UserProfile.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.UserProfile.Handlers
{
    public class CreateUserProfileHandler : ICommandHandler<CreateUserProfile>
    {
        private readonly IUserProfileRepository _repository;

        public CreateUserProfileHandler(IUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<IEvent>> Handle(CreateUserProfile command)
        {
            var profile = new UserProfile(command);

            await _repository.AddAsync(profile);

            return new IEvent[] { };
        }
    }
}
