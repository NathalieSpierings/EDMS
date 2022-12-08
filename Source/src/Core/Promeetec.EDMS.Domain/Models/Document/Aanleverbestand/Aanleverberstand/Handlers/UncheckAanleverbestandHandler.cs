using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Commands;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Handlers
{
	public class UncheckAanleverbestandHandler : ICommandHandler<UncheckAanleverbestand>
	{
		private readonly IAanleverbestandRepository _repository;

		public UncheckAanleverbestandHandler(IAanleverbestandRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<IEvent>> Handle(UncheckAanleverbestand command)
		{
			var bestand = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id);
			if (bestand == null)
				throw new ApplicationException($"Aanleverbestand met Id {command.Id} niet gevonden.");

			bestand.Uncheck();
			await _repository.UpdateAsync(bestand);

			return new IEvent[] { };
		}
	}
}
