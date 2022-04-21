using Promeetec.EDMS.Domain.Domain.Betrokkene.Organisatie;
using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Domain.Document.Rapportage;

public class Rapportage : Bestand.Bestand
{
    /// <summary>
    /// The referentie for the rapportage.
    /// </summary>
    [Required, StringLength(200)]
    public string Referentie { get; set; }


    /// <summary>
    /// The kind of rapportage.
    /// </summary>
    public RapportageSoort RapportageSoort { get; set; }


    #region Navigation properties

    /// <summary>
    /// The unique identifier of the organisatie for the rapportage.
    /// </summary>
    public Guid OrganisatieId { get; set; }

    /// <summary>
    /// Reference to the organisatie for the rapportage.
    /// </summary>
    public Organisatie Organisatie { get; set; }

    #endregion


    public Rapportage() { }
}