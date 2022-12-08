using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Document.Rapportage.Events
{
	public class RapportageAangemaakt : EventBase
	{
		public string Bestandsnaam { get; set; }
		public int Bestandsgrootte { get; set; }
		public string ReferentiePromeetec { get; set; }
		public string Eigenaar { get; set; }
		public string Organisatie { get; set; }
		public string RapportageSoort { get; set; }

		public Guid EigenaarId { get; set; }

	}
}