using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Handlers
{
	public class CheckAanleverbestandHandler : ICommandHandler<CheckAanleverbestand>
	{
		private readonly IAanleverbestandRepository _repository;

		public CheckAanleverbestandHandler(IAanleverbestandRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<IEvent>> Handle(CheckAanleverbestand command)
		{
			var bestand = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id);
			if (bestand == null)
				throw new ApplicationException($"Aanleverbestand met Id {command.Id} niet gevonden.");

			bestand.Check();
			await _repository.UpdateAsync(bestand);

			return new IEvent[] { };
		}
	}
}
