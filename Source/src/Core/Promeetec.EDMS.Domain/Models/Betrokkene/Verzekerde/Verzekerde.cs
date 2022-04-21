using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Promeetec.EDMS.Domain.Models.Modules.Adresboek;
using Promeetec.EDMS.Domain.Models.Modules.GLI.Behandelplan;
using Promeetec.EDMS.Domain.Models.Modules.GLI.Intake;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;
using Promeetec.EDMS.Domain.Models.Shared;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde;

public class Verzekerde : AggregateRoot
{
    /// <summary>
    /// The Bsn  of the insured person.
    /// </summary>
    [MaxLength(128)]
    public string Bsn { get; set; }


    /// <summary>
    /// The height of the insured person.
    /// </summary>
    public double? Lengte { get; set; }

    public Persoon.Persoon Persoon { get; set; }


    /// <summary>
    /// The AGBcode verijzer of the insured person.
    /// </summary>
    [MaxLength(20)]
    public string AgbCodeVerwijzer { get; set; }

    /// <summary>
    /// The name of the referrer.
    /// </summary>
    [MaxLength(256)]
    public string NaamVerwijzer { get; set; }

    /// <summary>
    /// The referral date.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime? Verwijsdatum { get; set; }

    /// <summary>
    /// The status of the insured person.
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
    [Required]
    public Guid AangemaaktDoorId { get; set; }


    /// <summary>
    /// The name of medewerker who created the insured person.
    /// </summary>
    public string AangemaaktDoor { get; set; }


    #region Navigation properties
    
    public Guid AdresboekId { get; set; }
    public virtual Adresboek Adresboek { get; set; }
    
    public Guid? AdresId { get; set; }
    public virtual Adres.Adres Adres { get; set; }

    public Guid? ZorgprofielId { get; set; }
    public virtual Zorgprofiel Zorgprofiel { get; set; }

    public Guid? ZorgverzekeringId { get; set; }
    public virtual Zorgverzekering.Zorgverzekering Zorgverzekering { get; set; }

    public virtual ICollection<VerzekerdeToAdres> Adressen { get; set; }
    public virtual ICollection<VerzekerdeToZorgprofiel> Zorgprofielen { get; set; }
    public virtual ICollection<VerzekerdeToUser> Users { get; set; }
    public virtual ICollection<GliBehandelplan> GliBehandelplannen { get; set; }
    public virtual ICollection<GliIntake> GliIntakes { get; set; }
    public virtual ICollection<VerzekerdeToZorgverzekering> Zorgverzekeringen { get; set; }
    public virtual ICollection<Weegmoment.Weegmoment> WeegMomenten { get; set; }
    public virtual ICollection<VerbruiksmiddelPrestatie> VerbruiksmiddelPrestaties { get; set; }

    #endregion


    /// <summary>
    /// Creates an empty verzekerde
    /// </summary>
    public Verzekerde()
    {

    }

    //public Verzekerde(NieuweVerzekerde cmd)
    //{
    //    AangemaaktDoorId = cmd.UserId;
    //    AangemaaktDoor = cmd.UserDisplayName;
    //    AdresboekId = cmd.AdresboekId;
    //    Adres = cmd.Adres;
    //    Zorgverzekering = cmd.Zorgverzekering;
    //    Zorgprofiel = cmd.Zorgprofiel;

    //    cmd.Persoon.Voorletters = PersoonExtensions.VerwijderPunten(cmd.Persoon.Voorletters);
    //    cmd.Persoon.FormeleNaam = PersoonExtensions.SetFormeleNaam(PersoonExtensions.VerwijderPunten(cmd.Persoon.Voorletters), cmd.Persoon.Tussenvoegsel, cmd.Persoon.Achternaam, cmd.Persoon.Voornaam);
    //    cmd.Persoon.VolledigeNaam = PersoonExtensions.SetVolledigeNaam(PersoonExtensions.VerwijderPunten(cmd.Persoon.Voorletters), cmd.Persoon.Tussenvoegsel, cmd.Persoon.Achternaam, cmd.Persoon.Voornaam);
    //    Persoon = cmd.Persoon;

    //    Verwijsdatum = cmd.Verwijsdatum;

    //    AddAndApplyEvent(new VerzekerdeAangemaakt
    //    {
    //        AggregateRootId = cmd.AggregateRootId,
    //        //UserDisplayName = cmd.UserDisplayName,
    //        UserId = cmd.UserId,
    //        Bsn = cmd.Bsn,
    //        AgbCodeVerwijzer = cmd.AgbCodeVerwijzer,
    //        NaamVerwijzer = cmd.NaamVerwijzer,
    //        Verwijsdatum = cmd.Verwijsdatum.HasValue ? cmd.Verwijsdatum.Value.ToString("dd-MM-yyyy") : string.Empty,
    //        Persoon = new Persoon.Persoon
    //        {
    //            Geboortedatum = cmd.Persoon.Geboortedatum,
    //            VolledigeNaam = cmd.Persoon.VolledigeNaam
    //        }
    //    });
    //}


    //public void Update(double lengte)
    //{
    //    Lengte = lengte;
    //}

    //public void Update(UpdateVerzekerde cmd)
    //{
    //    Zorgverzekering = cmd.Zorgverzekering;
    //    Adres = cmd.Adres;
    //    Zorgprofiel = cmd.Zorgprofiel;
    //    cmd.Persoon.Voorletters = PersoonExtensions.VerwijderPunten(cmd.Persoon.Voorletters);
    //    cmd.Persoon.FormeleNaam = PersoonExtensions.SetFormeleNaam(PersoonExtensions.VerwijderPunten(cmd.Persoon.Voorletters), cmd.Persoon.Tussenvoegsel, cmd.Persoon.Achternaam, cmd.Persoon.Voornaam);
    //    cmd.Persoon.VolledigeNaam = PersoonExtensions.SetVolledigeNaam(PersoonExtensions.VerwijderPunten(cmd.Persoon.Voorletters), cmd.Persoon.Tussenvoegsel, cmd.Persoon.Achternaam, cmd.Persoon.Voornaam);
    //    Persoon = cmd.Persoon;

    //    Verwijsdatum = cmd.Verwijsdatum;

    //    AddAndApplyEvent(new VerzekerdeGewijzigd
    //    {
    //        AggregateRootId = Id,
    //        UserId = cmd.UserId,
    //        //UserDisplayName = cmd.UserDisplayName,
    //        Bsn = cmd.Bsn,
    //        AgbCodeVerwijzer = cmd.AgbCodeVerwijzer,
    //        NaamVerwijzer = cmd.NaamVerwijzer,
    //        Verwijsdatum = cmd.Verwijsdatum.HasValue ? cmd.Verwijsdatum.Value.ToString("dd-MM-yyyy") : string.Empty,
    //        Persoon = new Persoon.Persoon
    //        {
    //            Geboortedatum = cmd.Persoon.Geboortedatum,
    //            VolledigeNaam = cmd.Persoon.VolledigeNaam
    //        }
    //    });
    //}


    //public void Share(ToewijzenVerzekerde cmd)
    //{
    //    Shared = cmd.Shared;
    //}

    //public void Activate(ActiveerVerzekerde cmd)
    //{
    //    Status = Status.Actief;
    //}

    //public void Deactivate(DeactiveerVerzekerde cmd)
    //{
    //    Status = Status.Inactief;
    //}

    //public void ActivateMetZorgprofiel(ActiveerVerzekerdeMetZorgprofiel cmd)
    //{
    //    Status = Status.Actief;
    //    Zorgprofiel.ProfielStartdatum = cmd.ProfielStartdatum;
    //    Zorgprofiel.ProfielEinddatum = null;
    //}

    //public void DeactivateMetZorgprofiel(DeactiveerVerzekerdeMetZorgprofiel cmd)
    //{
    //    Status = Status.Inactief;
    //    Zorgprofiel.ProfielEinddatum = cmd.ProfielEinddatum;
    //}

    //public void Delete(VerwijderVerzekerde cmd)
    //{
    //    Status = Status.Verwijderd;

    //    if (Zorgprofiel != null)
    //    {
    //        // Zorgprofiel.ProfielEinddatum = DateTime.Now;
    //        Zorgprofiel = null;
    //    }
    //}

    //public void Undelete(UndeleteVerzekerde cmd)
    //{
    //    Status = Status.Actief;
    //    Zorgprofiel = null;
    //}


    //#region Private

    //private void Apply(VerzekerdeAangemaakt @event)
    //{
    //    Id = @event.AggregateRootId;
    //    Status = Status.Actief;
    //    Shared = false;
    //    AangemaaktOp = DateTime.Now;
    //    Bsn = @event.Bsn;
    //    AgbCodeVerwijzer = @event.AgbCodeVerwijzer;
    //    NaamVerwijzer = @event.NaamVerwijzer;
    //}

    //private void Apply(VerzekerdeGewijzigd @event)
    //{
    //    Bsn = @event.Bsn;
    //    AgbCodeVerwijzer = @event.AgbCodeVerwijzer;
    //    NaamVerwijzer = @event.NaamVerwijzer;
    //}

    //#endregion
}
