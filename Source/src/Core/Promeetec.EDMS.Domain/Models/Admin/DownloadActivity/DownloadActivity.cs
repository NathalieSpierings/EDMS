using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Portaal.Core.Domain;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Bestand;

namespace Promeetec.EDMS.Portaal.Domain.Models.Admin.DownloadActivity;

public class DownloadActivity : AggregateRoot
{
    /// <summary>
    /// The download date.
    /// </summary>
    [Required]
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