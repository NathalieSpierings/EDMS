using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Samenvatting;

public class AanleverbestandSamenvatting : AggregateRoot
{
    /// <summary>
    /// The EI standaard for the samenvatting.
    /// </summary>
    [MaxLength(200)]
    public string EiStandaard { get; set; }


    /// <summary>
    /// The total insured person records for the samenvatting.
    /// </summary>
    public int? AantalVerzekerdeRecords { get; set; }


    /// <summary>
    /// The total prestatie records for the samenvatting.
    /// </summary>
    public int? AantalPrestatieRecords { get; set; }


    /// <summary>
    /// The total declaratie amount for the samenvatting.
    /// </summary>
    [Column(TypeName = "decimal(18,4)")]
    public decimal? TotaalDeclaratiebedrag { get; set; }


    /// <summary>
    /// The zorgverlenerscode for the samenvatting.
    /// </summary>
    public int? ZorgverlenersCode { get; set; }


    /// <summary>
    /// The praktijk code for the samenvatting.
    /// </summary>
    public int? Praktijkcode { get; set; }


    /// <summary>
    /// The instellingscode for the samenvatting.
    /// </summary>
    public int? Instellingscode { get; set; }


    /// <summary>
    /// The instellingscode for the samenvatting.
    /// </summary>
    public bool Processed { get; set; } = true;


    /// <summary>
    /// The skipped rows for the samenvatting.
    /// </summary>
    public int OvergeslagenRows { get; set; }


    #region Navigation properties

    public Guid? BestandId { get; set; }
    public virtual Bestand.Bestand Bestand { get; set; }

    #endregion


    /// <summary>
    /// Creates an empty aanleverbestand samenvatting.
    /// </summary>
    public AanleverbestandSamenvatting()
    {

    }

}