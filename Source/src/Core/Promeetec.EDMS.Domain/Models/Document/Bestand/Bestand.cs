﻿using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Samenvatting;
using Promeetec.EDMS.Domain.Models.Document.Bestand.Commands;

namespace Promeetec.EDMS.Domain.Models.Document.Bestand;

public class Bestand : AggregateRoot
{
	/// <summary>
	/// The name of the file.
	/// </summary>
	[Required, MaxLength(450)]
	public string FileName { get; set; }

	/// <summary>
	/// The size of the file.
	/// </summary>
	[Required]
	public int FileSize { get; set; }

	/// <summary>
	/// The extension of the file.
	/// </summary>
	[MaxLength(50)]
	public string? Extension { get; set; }

	/// <summary>
	/// The mime type of the file.
	/// </summary>
	[Required, MaxLength(450)]
	public string MimeType { get; set; }

	/// <summary>
	/// The content of the file.
	/// </summary>
	public byte[] Data { get; set; }


	/// <summary>
	/// The time stamp of when the record has been created.
	/// </summary>
	public DateTime AangemaaktOp { get; set; }

	/// <summary>
	/// Unique identiefier of the creator of the file.
	/// </summary>
	public Guid? AangemaaktDoor { get; set; }

	/// <summary>
	/// Name of the creator of the file.
	/// </summary>
	[MaxLength(450)]
	public string AangemaaktDoorNaam { get; set; }

	/// <summary>
	/// The last edit date of the file.
	/// </summary>
	public DateTime? AangepastOp { get; set; }

	/// <summary>
	/// Name of the last editor for the file.
	/// </summary>
	public Guid? AangepastDoor { get; set; }

	#region Navigation properties

	public Guid EigenaarId { get; set; }
	public virtual Medewerker Eigenaar { get; set; }

	public Guid OrganisatieId { get; set; }
	public virtual Organisatie Organisatie { get; set; }
	public virtual AanleverbestandSamenvatting Samenvatting { get; set; }

	#endregion


	/// <summary>
	/// Creates an empty bestand.
	/// </summary>
	public Bestand()
	{

	}

	/// <summary>
	/// Creates a country.
	/// </summary>
	/// <param name="cmd">The create bestand command.</param>
	public Bestand(CreateBestand cmd)
	{
		Id = cmd.Id;

		FileName = cmd.FileName;
		FileSize = cmd.FileSize;
		Extension = cmd.Extension;
		MimeType = cmd.MimeType;
		Data = cmd.Data;
		OrganisatieId = cmd.OrganisatieId;
		EigenaarId = cmd.EigenaarId;
		AangemaaktOp = DateTime.Now;
		AangemaaktDoor = cmd.UserId;
		AangemaaktDoorNaam = cmd.UserDisplayName;
	}

	/// <summary>
	/// Update the filename of the bestand.
	/// </summary>
	/// <param name="cmd">The update bestand command.</param>
	public void Update(UpdateBestand cmd)
	{
		FileName = cmd.FileName;
		EigenaarId = cmd.EigenaarId;
		AangepastOp = DateTime.Now;
		AangepastDoor = cmd.UserId;
	}

	/// <summary>
	/// Update the filename of the bestand.
	/// </summary>
	/// <param name="cmd">The update bestand command.</param>
	public void UpdateEigenaar(UpdateEigenaarBestand cmd)
	{
		EigenaarId = cmd.EigenaarId;
		AangepastOp = DateTime.Now;
		AangepastDoor = cmd.UserId;
	}
}