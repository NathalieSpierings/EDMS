using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.UserProfile.Commands;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.UserProfile.Handlers
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
