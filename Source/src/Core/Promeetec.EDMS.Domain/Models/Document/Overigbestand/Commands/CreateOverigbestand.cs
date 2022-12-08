using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Document.Overigbestand.Commands
{
	public class CreateOverigbestand : CommandBase
	{
		public string FileName { get; set; }
		public string MimeType { get; set; }
		public string Extension { get; set; }
		public int FileSize { get; set; }
		public byte[] Data { get; set; }
		public Guid EigenaarId { get; set; }
		public Guid AanleveringId { get; set; }
	}
}