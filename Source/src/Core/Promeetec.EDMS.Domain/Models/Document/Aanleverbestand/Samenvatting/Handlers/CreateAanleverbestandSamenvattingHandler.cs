using Promeetec.EDMS.Domain.Document.Aanleverbestand.Aanleverberstand;
using Promeetec.EDMS.Domain.Document.Aanleverbestand.Samenvatting.Commands;

namespace Promeetec.EDMS.Domain.Document.Aanleverbestand.Samenvatting.Handlers
{
    public class CreateAanleverbestandSamenvattingHandler : ICommandHandler<CreateAanleverbestandSamenvatting>
    {
        private readonly IAanleverbestandRepository _repository;

        public CreateAanleverbestandSamenvattingHandler(IAanleverbestandRepository repository)
        {
            _repository = repository;
        }

        public CommandResponse Handle(CreateAanleverbestandSamenvatting command)
        {
            var aanleverbestand = _repository.GetById(command.AanleverbestandId);
            if (aanleverbestand != null)
            {
                try
                {
                    aanleverbestand.CreateSamenvatting(command);
                    _repository.Update(aanleverbestand);
                }
                catch
                {
                    // ignored
                }
            }

            return new CommandResponse
            {
                Events = aanleverbestand.Events
            };
        }
    }
}
