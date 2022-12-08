using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Samenvatting.Commands;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Samenvatting.Handlers
{
	public class CreateAanleverbestandSamenvattingHandler : ICommandHandler<CreateAanleverbestandSamenvatting>
	{
		private readonly IAanleverbestandRepository _repository;

		public CreateAanleverbestandSamenvattingHandler(IAanleverbestandRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<IEvent>> Handle(CreateAanleverbestandSamenvatting command)
		{
			var aanleverbestand = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.AanleverbestandId);
			if (aanleverbestand == null)
				throw new ApplicationException($"Aanleverbestand met Id {command.Id} niet gevonden.");

			try
			{
				aanleverbestand.CreateSamenvatting(command);
				await _repository.UpdateAsync(aanleverbestand);
			}
			catch (Exception ex)
			{
				// TODO: Log exception
			}

			return new IEvent[] { };
		}
	}
}
