using Promeetec.EDMS.Domain.Modules.Declaratie.Aanleverbericht.Commands;

namespace Promeetec.EDMS.Domain.Modules.Declaratie.Aanleverbericht.Handlers
{
    public class CreateAanleverberichtHandler : ICommandHandlerAsync<CreateAanleverbericht>
    {
        private readonly IAanleverberichtRepository _repository;
        private readonly IAanleveringRepository _aanleveringRepository;

        public CreateAanleverberichtHandler(IAanleverberichtRepository repository, IAanleveringRepository aanleveringRepository)
        {
            _repository = repository;
            _aanleveringRepository = aanleveringRepository;
        }

        public async Task<CommandResponse> HandleAsync(CreateAanleverbericht command)
        {
            var aanlevering = await _aanleveringRepository.GetByIdAsync(command.AanleveringId);
            if (aanlevering == null)
                throw new Exception($"Aanlevering van aanleverbericht niet gevonden. AanleveringId: {command.AanleveringId}");

            var order = aanlevering.BerichtSortOrder(command);
            var aanleverbericht = new Modules.Declaratie.Aanleverbericht.Aanleverbericht(command, order);

            await _repository.AddAsync(aanleverbericht);

            return new CommandResponse
            {
                Events = aanleverbericht.Events
            };
        }
    }
}
