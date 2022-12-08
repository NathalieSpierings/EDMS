using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Admin.EiStandaard;
using Promeetec.EDMS.Domain.Models.Admin.Zorgstraat;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Commands;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Samenvatting;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Samenvatting.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;

namespace Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand;

public class Aanleverbestand : Bestand.Bestand
{
	/// <summary>
	/// The period of the aanleverbestand.
	/// </summary>
	[MaxLength(20)]
	public string Periode { get; set; }

	/// <summary>
	/// Indicator if the aanleverbestand is checked yes or no.
	/// </summary>
	public bool Gecontroleerd { get; set; }


	#region Navigation properties

	public Guid? ZorgstraatId { get; set; }
	public virtual Zorgstraat Zorgstraat { get; set; }

	public Guid? EiStandaardId { get; set; }
	public virtual EiStandaard EiStandaard { get; set; }

	public Guid? AanleveringId { get; set; }
	public virtual Aanlevering Aanlevering { get; set; }


	#endregion

	/// <summary>
	/// Creates an empty aanleverbestand.
	/// </summary>
	public Aanleverbestand()
	{

	}

	/// <summary>
	/// Creates an aanleverbestand.
	/// </summary>
	/// <param name="cmd">The create aanleverbestand command.</param>
	public Aanleverbestand(CreateAanleverbestand cmd)
	{
		Id = cmd.Id;

		FileName = cmd.FileName;
		Extension = cmd.Extension;
		FileSize = cmd.FileSize;
		MimeType = cmd.MimeType;
		Data = cmd.Data;
		Periode = cmd.Periode;
		EigenaarId = cmd.EigenaarId;
		ZorgstraatId = cmd.ZorgstraatId;
		AanleveringId = cmd.AanleveringId;
		EiStandaardId = cmd.EiStandaardId;
		AangemaaktOp = DateTime.Now;
		AangemaaktDoor = cmd.UserId;
		AangemaaktDoorNaam = cmd.UserDisplayName;
	}

	/// <summary>
	/// Update the details of the aanleverbestand.
	/// </summary>
	/// <param name="cmd">The update aanleverbestand command.</param>
	public void Update(UpdateAanleverbestand cmd)
	{
		Periode = cmd.Periode;
		ZorgstraatId = cmd.ZorgstraatId;
		EigenaarId = cmd.EigenaarId;
		AangepastOp = DateTime.Now;
		AangepastDoor = cmd.UserId;
	}

	/// <summary>
	/// Mark the document as checked.
	/// </summary>
	public void Check()
	{
		Gecontroleerd = true;
	}

	/// <summary>
	/// Mark the document as unchecked.
	/// </summary>
	public void Uncheck()
	{
		Gecontroleerd = false;
	}


	public void CreateSamenvatting(CreateAanleverbestandSamenvatting cmd)
	{
		var samenvatting = new AanleverbestandSamenvatting
		{
			EiStandaard = cmd.EiStandaard,
			AantalVerzekerdeRecords = cmd.AantalVerzekerdeRecords,
			AantalPrestatieRecords = cmd.AantalPrestatieRecords,
			TotaalDeclaratiebedrag = cmd.TotaalDeclaratiebedrag,
			ZorgverlenersCode = cmd.Zorgverlenerscode,
			Praktijkcode = cmd.Praktijkcode,
			Instellingscode = cmd.Instellingscode,
			Processed = cmd.Processed,
			OvergeslagenRows = cmd.OvergeslagenRows,
		};
		Samenvatting = samenvatting;
	}

}