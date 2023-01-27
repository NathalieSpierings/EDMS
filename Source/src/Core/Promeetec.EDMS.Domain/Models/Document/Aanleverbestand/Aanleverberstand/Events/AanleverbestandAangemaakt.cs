using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Events
{
	public class AanleverbestandAangemaakt : EventBase
	{
		public string Bestandsnaam { get; set; }
		public int Bestandsgrootte { get; set; }
		public string Periode { get; set; }
		public string? Zorgstraat { get; set; }
		public string Eigenaar { get; set; }
		public string EiStandaardCode { get; set; }
		public string EiStandaardNaam { get; set; }
		public Guid? ZorgstraatId { get; set; }
		public Guid? EiStandaardId { get; set; }
		public Guid? AanleveringId { get; set; }
		public Guid EigenaarId { get; set; }
	}
}