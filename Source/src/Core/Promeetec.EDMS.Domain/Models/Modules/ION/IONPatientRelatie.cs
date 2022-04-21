using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;

namespace Promeetec.EDMS.Domain.Models.Modules.ION;

public class IONPatientRelatie : AggregateRoot
{
    /// <summary>
    /// The period of the ION populatie.
    /// </summary>
    [Required, Column(TypeName = "datetime2")]
    public DateTime Periode { get; set; }

    /// <summary>
    /// The AGB code zorgverlener of the ION populatie.
    /// </summary>
    [MaxLength(50)]
    public string AgbCodeZorgverlener { get; set; }

    /// <summary>
    /// The AGB code onderneming of the ION populatie.
    /// </summary>
    [MaxLength(50)]
    public string AgbCodeOnderneming { get; set; }

    /// <summary>
    /// The date of birth of the patient.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime Geboortedatum { get; set; }

    /// <summary>
    /// The initials of the patient.
    /// </summary>
    [Required, MaxLength(20)]
    public string Voorletters { get; set; }

    /// <summary>
    /// The surname of the patient.
    /// </summary>
    [MaxLength(20)]
    public string Tussenvoegsel { get; set; }

    /// <summary>
    /// The last name of the patient.
    /// </summary>
    [Required, MaxLength(256)]
    public string Achternaam { get; set; }

    /// <summary>
    /// The BSN of the patient.
    /// </summary>
    [Required, MaxLength(20)]
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

    public Guid MedewerkerId { get; set; }
    public virtual Medewerker Medewerker { get; set; }

    public Guid OrganisatieId { get; set; }
    public virtual Organisatie Organisatie { get; set; }
    
    public Guid? ZorggroepRelatieId { get; set; }
    public virtual Organisatie ZorggroepRelatie { get; set; }

    #endregion


    /// <summary>
    /// Creates a new ION patient relatie.
    /// </summary>
    public IONPatientRelatie()
    {

    }

    //public IONPatientRelatie(CreatePatientRelatie cmd)
    //{
    //    Geboortedatum = cmd.Geboortedatum;
    //    Voorletters = cmd.Voorletters;
    //    Tussenvoegsel = cmd.Tussenvoegsel;
    //    Achternaam = cmd.Achternaam;
    //    Bsn = cmd.Bsn;
    //    Kwaliteitscategorie = cmd.Kwaliteitscategorie;
    //    IONZoekOptie = cmd.IONZoekOptie;
    //    ZorggroepRelatieId = cmd.ZorggroepRelatieId;

    //    AddAndApplyEvent(new PatientRelatieAangemaakt
    //    {
    //        AggregateRootId = Id,
    //        UserId = cmd.UserId,
    //        // UserDisplayName = cmd.UserDisplayName,

    //        MedewerkerId = cmd.MedewerkerId,
    //        OrganisatieId = cmd.OrganisatieId,
    //        PatientrelatiesZoekoptie = cmd.IONZoekOptie.GetDisplayName(),
    //        Kwaliteitscategorie = cmd.Kwaliteitscategorie.GetDisplayName(),
    //        Periode = cmd.Periode,
    //        AgbCodeZorgverlener = cmd.AgbCodeZorgverlener,
    //        AgbCodePraktijk = cmd.AgbCodePraktijk,
    //        AantalRelaties = cmd.AantalRelaties,
    //        Verwerkt = "Nee",
    //        AangeleverdOp = DateTime.Now
    //    });
    //}

    //public void Raadpleeg(RaadpleegION cmd)
    //{
    //    AddAndApplyEvent(new IONGeraadpleegd
    //    {
    //        AggregateRootId = Id,
    //        UserId = cmd.UserId,
    //        // UserDisplayName = cmd.UserDisplayName,
    //        PatientrelatiesZoekoptie = cmd.IONZoekOptie.GetDisplayName(),
    //        AgbCodeZorgverlener = cmd.AgbCodeZorgverlener,
    //        AgbCodePraktijk = cmd.AgbCodePraktijk,
    //        AantalRelaties = cmd.AantalRelaties,
    //        Periode = cmd.Periode
    //    });
    //}

    //public void Verwerk(VerwerkPatientRelatie cmd)
    //{
    //    if (Verwerkt)
    //        throw new Exception("Deze ION Populatie is al verwerkt");

    //    AddAndApplyEvent(new PatientRelatieVerwerkt
    //    {
    //        AggregateRootId = Id,
    //        UserId = cmd.UserId,
    //        // UserDisplayName = cmd.UserDisplayName,
    //        Verwerkt = "Ja"
    //    });
    //}



    //private void Apply(PatientRelatieAangemaakt @event)
    //{
    //    Id = @event.AggregateRootId;

    //    MedewerkerId = @event.MedewerkerId;
    //    OrganisatieId = @event.OrganisatieId;
    //    Periode = @event.Periode;
    //    AgbCodeZorgverlener = @event.AgbCodeZorgverlener;
    //    AgbCodeOnderneming = @event.AgbCodePraktijk;
    //    AantalRelaties = @event.AantalRelaties;
    //    Verwerkt = false;
    //    AangeleverdOp = @event.AangeleverdOp;
    //}


    //private void Apply(IONGeraadpleegd @event)
    //{
    //}


    //private void Apply(PatientRelatieVerwerkt @event)
    //{
    //    Verwerkt = true;
    //}
}
