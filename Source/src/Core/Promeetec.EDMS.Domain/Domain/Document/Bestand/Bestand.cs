using OpenCqrs.Domain;
using Promeetec.EDMS.Domain.Domain.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Domain.Document.Aanleverbestand.Samenvatting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promeetec.EDMS.Domain.Domain.Document.Bestand;

public class Bestand : AggregateRoot
{
    [Required, StringLength(450)]
    public string FileName { get; set; }

    [Required]
    public int FileSize { get; set; }


    [StringLength(50)]
    public string Extension { get; set; }


    [Required, StringLength(450)]
    public string MimeType { get; set; }

    public byte[] Data { get; set; }


    [Required, Column(TypeName = "datetime2")]
    public DateTime AangemaaktOp { get; set; }

    public Guid? AangemaaktDoor { get; set; }


    [StringLength(450)]
    public string AangemaaktDoorNaam { get; set; }


    [Column(TypeName = "datetime2")]
    public DateTime? AangepastOp { get; set; }

    public Guid? AangepastDoor { get; set; }


    #region Navigation properties

    public Guid EigenaarId { get; set; }
    public Medewerker Eigenaar { get; set; }

    public AanleverbestandSamenvatting Samenvatting { get; set; }

    #endregion



    public Bestand()
    {
    }

}