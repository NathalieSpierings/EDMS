using OpenCqrs.Domain;
using Promeetec.EDMS.Domain.Domain.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Domain.Document.Bestand;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promeetec.EDMS.Domain.Domain.Admin.DownloadActivity;

public class DownloadActivity : AggregateRoot
{
    /// <summary>
    /// The download date.
    /// </summary>
    [Required, Column(TypeName = "datetime2")]
    public DateTime GedownloadOp { get; set; }


    /// <summary>
    /// The type of document.
    /// </summary>
    public BestandSoort BestandSoort { get; set; }


    #region Navigation properties

    /// <summary>
    /// The unique identifier of the document which is downloaded.
    /// </summary>
    public Guid BestandId { get; set; }
    public Document.Bestand.Bestand Bestand { get; set; }


    /// <summary>
    /// The unique identifier of the medewerker who downloaded the document.
    /// </summary>
    public Guid MedewerkerId { get; set; }

    /// <summary>
    /// Reference to the medewerker who downloaded the document.
    /// </summary>
    public Medewerker Medewerker { get; set; }



    /// <summary>
    /// The unique identifier of the voorraad the document belongs to.
    /// </summary>
    public Guid? VoorraadId { get; set; }

    /// <summary>
    /// The unique identifier of the aanlevering the document belongs to.
    /// </summary>
    public Guid? AanleveringId { get; set; }

    #endregion


    public DownloadActivity() { }
}