using Promeetec.EDMS.Domain.Betrokkene.UserProfile.Commands;

namespace Promeetec.EDMS.Domain.Betrokkene.UserProfile.Handlers
{
    public class UpdatePageSizeHandler : ICommandHandlerAsync<UpdatePageSize>
    {
        private readonly IUserProfileRepository _repository;

        public UpdatePageSizeHandler(IUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(UpdatePageSize command)
        {
            var userProfile = await _repository.GetByIdAsync(command.AggregateRootId);
            if (userProfile == null)
                throw new ApplicationException($"Profiel niet gevonden. Id: {command.AggregateRootId}");

            userProfile.UpdatePageSize(command);
            await _repository.UpdateAsync(userProfile);

            return new CommandResponse
            {
                Events = userProfile.Events
            };
        }
    }
}