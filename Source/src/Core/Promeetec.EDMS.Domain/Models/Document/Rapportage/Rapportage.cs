using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Document.Rapportage.Commands;

namespace Promeetec.EDMS.Domain.Models.Document.Rapportage;

public class Rapportage : Bestand.Bestand
{
	/// <summary>
	/// The referentie for the rapportage.
	/// </summary>
	[Required, MaxLength(200)]
	public string Referentie { get; set; }

	/// <summary>
	/// The kind of rapportage.
	/// </summary>
	public RapportageSoort RapportageSoort { get; set; }


	#region Navigation properties

	public Guid OrganisatieId { get; set; }
	public virtual Organisatie Organisatie { get; set; }

	#endregion

	/// <summary>
	/// Creates an empty rapportage file.
	/// </summary>
	public Rapportage()
	{

	}

	/// <summary>
	/// Creates an rapportage.
	/// </summary>
	/// <param name="cmd">The create rapportage command.</param>
	public Rapportage(CreateRapportage cmd)
	{
		Id = cmd.Id;

		FileName = cmd.FileName;
		FileSize = cmd.FileSize;
		Extension = cmd.Extension;
		MimeType = cmd.MimeType;
		Data = cmd.Data;
		EigenaarId = cmd.EigenaarId;
		OrganisatieId = cmd.OrganisatieId;
		AangemaaktOp = DateTime.Now;
		AangemaaktDoorId = cmd.UserId;
		AangemaaktDoor = cmd.UserDisplayName;

		RapportageSoort = cmd.RapportageSoort;
		Referentie = cmd.Referentie;
	}
}