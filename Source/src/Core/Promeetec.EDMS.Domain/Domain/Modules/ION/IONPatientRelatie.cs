using OpenCqrs.Domain;
using Promeetec.EDMS.Domain.Domain.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Domain.Betrokkene.Organisatie;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promeetec.EDMS.Domain.Domain.Modules.ION;

public class IONPatientRelatie : AggregateRoot
{
    /// <summary>
    /// The period of the ION populatie.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime Periode { get; set; }

    /// <summary>
    /// The AGB code zorgverlener of the ION populatie.
    /// </summary>
    [StringLength(50)]
    public string AgbCodeZorgverlener { get; set; }


    /// <summary>
    /// The AGB code onderneming of the ION populatie.
    /// </summary>
    [StringLength(50)]
    public string AgbCodeOnderneming { get; set; }

    /// <summary>
    /// The date of birth of the patient.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime Geboortedatum { get; set; }

    /// <summary>
    /// The initials of the patient.
    /// </summary>
    [StringLength(20)]
    public string Voorletters { get; set; }

    /// <summary>
    /// The surname of the patient.
    /// </summary>
    [StringLength(20)]
    public string Tussenvoegsel { get; set; }


    /// <summary>
    /// The last name of the patient.
    /// </summary>
    [StringLength(256)]
    public string Achternaam { get; set; }


    /// <summary>
    /// The BSN of the patient.
    /// </summary>
    [StringLength(20)]
    public string Bsn { get; set; }


    /// <summary>
    /// The kwaliteitscategorie.
    /// </summary>
    public Kwaliteitscategorie Kwaliteitscategorie { get; set; }

    /// <summary>
    /// The ION search option.
    /// </summary>
    public IONZoekOptie IONZoekOptie { get; set; }


    /// <summary>
    /// Indicator if the ION populatie is done or not.
    /// </summary>
    public bool Verwerkt { get; set; }


    /// <summary>
    /// The total patient relationships found.
    /// </summary>
    public int AantalRelaties { get; set; }


    /// <summary>
    /// The date when the ION populatie is delivered.
    /// </summary>
    public DateTime AangeleverdOp { get; set; }


    /// <summary>
    /// The unique indentifier of the user who consulted the ION populatie.
    /// </summary>
    public Guid RaadplegerId { get; set; }

    /// <summary>
    /// The name of the user who consulted the ION populatie.
    /// </summary>
    public string RaadplegerNaam { get; set; }


    /// <summary>
    /// The time stamp of when the record has been created.
    /// </summary>
    public DateTime TimeStamp { get; set; }


    #region Navigation properties


    /// <summary>
    /// The unique identifier of the medewerker for the ION populatie.
    /// </summary>
    public Guid MedewerkerId { get; set; }

    /// <summary>
    /// Reference to the medewerker for the ION populatie.
    /// </summary>
    public Medewerker Medewerker { get; set; }


    /// <summary>
    /// The unique identifier of the organisatie for the ION populatie.
    /// </summary>
    public Guid OrganisatieId { get; set; }


    /// <summary>
    /// Reference to the organisatie for the ION populatie.
    /// </summary>
    public Organisatie Organisatie { get; set; }


    /// <summary>
    /// The unique identifier of the zorggroep relatie for the ION populatie.
    /// </summary>
    public Guid? ZorggroepRelatieId { get; set; }


    /// <summary>
    /// Reference to the zorggroep relatie for the ION populatie.
    /// </summary>
    public Organisatie ZorggroepRelatie { get; set; }

    #endregion

}
