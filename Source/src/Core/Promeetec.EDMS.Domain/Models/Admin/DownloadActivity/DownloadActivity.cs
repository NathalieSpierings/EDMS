using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Document.Bestand;

namespace Promeetec.EDMS.Domain.Models.Admin.DownloadActivity;

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

    public Guid? AanleveringId { get; set; }

    public Guid BestandId { get; set; }
    public virtual Bestand Bestand { get; set; }


    public Guid MedewerkerId { get; set; }
    public virtual Medewerker Medewerker { get; set; }

    #endregion


    /// <summary>
    /// Creates an empty download activity.
    /// </summary>
    public DownloadActivity()
    {
    }
}