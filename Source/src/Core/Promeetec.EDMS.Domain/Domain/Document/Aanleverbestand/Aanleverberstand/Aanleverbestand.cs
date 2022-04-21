using Promeetec.EDMS.Domain.Domain.Admin.EiStandaard;
using Promeetec.EDMS.Domain.Domain.Admin.Zorgstraat;
using Promeetec.EDMS.Domain.Domain.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Domain.Domain.Modules.Declaratie.Voorraad;
using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Domain.Document.Aanleverbestand.Aanleverberstand;

public class Aanleverbestand : Bestand.Bestand
{
    /// <summary>
    /// The period of the aanleverbestand.
    /// </summary>
    [StringLength(20)]
    public string Periode { get; set; }

    /// <summary>
    /// Indicator if the aanleverbestand is checked yes or no.
    /// </summary>
    public bool Gecontroleerd { get; set; }

    /// <summary>
    /// The workflow state of the aanleverbestand.
    /// </summary>
    [Required]
    [Display(Name = "Workflow status")]
    public AanleverbestandWorkflowState WorkFlowState { get; set; }


    #region Navigation properties

    /// <summary>
    /// The unique identifier of the zorgstraat for the aanleverbestand.
    /// </summary>
    public Guid? ZorgstraatId { get; set; }

    /// <summary>
    /// Reference to the zorgstraat for the aanleverbestand.
    /// </summary>
    public Zorgstraat Zorgstraat { get; set; }


    /// <summary>
    /// The unique identifier of the Ei-standaard for the aanleverbestand.
    /// </summary>
    public Guid? EiStandaardId { get; set; }

    /// <summary>
    /// Reference to the Ei-standaard for the aanleverbestand.
    /// </summary>
    public EiStandaard EiStandaard { get; set; }


    /// <summary>
    /// The unique identifier of the voorraad for the aanleverbestand.
    /// </summary>
    public Guid? VoorraadId { get; set; }

    /// <summary>
    /// Reference to the voorraad for the aanleverbestand.
    /// </summary>
    public Voorraad Voorraad { get; set; }


    /// <summary>
    /// The unique identifier of the aanlevering for the aanleverbestand.
    /// </summary>
    public Guid? AanleveringId { get; set; }

    /// <summary>
    /// Reference to the aanlevering for the aanleverbestand.
    /// </summary>
    public Aanlevering Aanlevering { get; set; }


    #endregion

    public Aanleverbestand() { }


}