using OpenCqrs.Domain;
using Promeetec.EDMS.Domain.Domain.Modules.Adresboek;
using Promeetec.EDMS.Domain.Domain.Modules.GLI.Behandelplan;
using Promeetec.EDMS.Domain.Domain.Modules.GLI.Intake;
using Promeetec.EDMS.Domain.Domain.Modules.Verbruiksmiddelen.Verbruiksmiddel;
using Promeetec.EDMS.Domain.Domain.Modules.Verbruiksmiddelen.Zorgprofiel;
using Promeetec.EDMS.Domain.Domain.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promeetec.EDMS.Domain.Domain.Betrokkene.Verzekerde;

public class Verzekerde : AggregateRoot
{
    /// <summary>
    /// The Bsn  of the insured person.
    /// </summary>
    [StringLength(128)]
    public string Bsn { get; set; }


    /// <summary>
    /// The height of the insured person.
    /// </summary>
    public double? Lengte { get; set; }

    public EDMS.Domain.Betrokkene.Persoon.Persoon Persoon { get; set; }


    /// <summary>
    /// The AGBcode verijzer of the insured person.
    /// </summary>
    [StringLength(20)]
    public string AgbCodeVerwijzer { get; set; }

    /// <summary>
    /// The name of the referrer.
    /// </summary>
    [StringLength(256)]
    public string NaamVerwijzer { get; set; }

    /// <summary>
    /// The referral date.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime? Verwijsdatum { get; set; }

    /// <summary>
    /// The status of the insured person.
    /// <list type="bullet">
    /// <item>
    /// <description>Inactief: insured person is grayed out in the addressbook.</description>
    /// </item>
    /// <item>
    /// <description>Actief: insured person is available in the addressbook.</description>
    /// </item>
    /// <item>
    /// <description>Verwijderd: insured person is soft deleted.</description>
    /// </item>
    /// </list>
    /// </summary>
    public Status Status { get; set; }


    /// <summary>
    /// Indicator if the insured person is shared with collegaues.
    /// </summary>
    public bool Shared { get; set; }


    /// <summary>
    /// The time stamp of when the record has been created.
    /// </summary>
    public DateTime TimeStamp { get; set; }


    /// <summary>
    /// The unique identifier of medewerker who created the insured person.
    /// </summary>
    public Guid AangemaaktDoorId { get; set; }


    /// <summary>
    /// The name of medewerker who created the insured person.
    /// </summary>
    public string AangemaaktDoor { get; set; }


    #region Navigation properties


    /// <summary>
    /// The unique identifier of the adressbook the insured person belongs to.
    /// </summary>
    public Guid AdresboekId { get; set; }


    /// <summary>
    /// Reference to the addressbook for the insured person.
    /// </summary>
    public Adresboek Adresboek { get; set; }


    /// <summary>
    /// The unique identifier of the adres the insured person.
    /// </summary>
    public Guid? AdresId { get; private set; }

    /// <summary>
    /// Reference to the address the insured person.
    /// </summary>
    public Adres.Adres Adres { get; set; }



    /// <summary>
    /// The unique identifier of the zorgprofiel for the insured person.
    /// </summary>
    public Guid? ZorgprofielId { get; private set; }

    /// <summary>
    /// Reference to the zorgprofiel for the insured person.
    /// </summary>
    public Zorgprofiel Zorgprofiel { get; set; }



    /// <summary>
    /// The unique identifier of the health insurance the insured person.
    /// </summary>
    public Guid? ZorgverzekeringId { get; private set; }
    /// <summary>
    /// Reference to the health insurance for the insured person.
    /// </summary>
    public Zorgverzekering.Zorgverzekering Zorgverzekering { get; set; }

    public IList<VerzekerdeToAdres> Adressen { get; set; } = new List<VerzekerdeToAdres>();
    public IList<VerzekerdeToZorgprofiel> Zorgprofielen { get; set; } = new List<VerzekerdeToZorgprofiel>();
    public List<VerzekerdeToUser> Users { get; set; } = new List<VerzekerdeToUser>();
    public IList<GliBehandelplan> GliBehandelplannen { get; set; } = new List<GliBehandelplan>();
    public IList<GliIntake> GliIntakes { get; set; } = new List<GliIntake>();
    public IList<VerzekerdeToZorgverzekering> Zorgverzekeringen { get; set; } = new List<VerzekerdeToZorgverzekering>();
    public IList<Weegmoment.Weegmoment> WeegMomenten { get; set; } = new List<Weegmoment.Weegmoment>();
    public IList<VerbruiksmiddelPrestatie> VerbruiksmiddelPrestaties { get; set; } = new List<VerbruiksmiddelPrestatie>();

    #endregion

    public Verzekerde() { }
}
