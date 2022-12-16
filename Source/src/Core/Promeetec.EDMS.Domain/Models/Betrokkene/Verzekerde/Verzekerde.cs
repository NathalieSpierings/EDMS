using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Adresboek;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Intake;
using Promeetec.EDMS.Domain.Models.Modules.GLI.Weegmoment;
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
    public string? Bsn { get; set; }


    /// <summary>
    /// The height of the insured person.
    /// </summary>
    public double? Lengte { get; set; }

    public Persoon.Persoon Persoon { get; set; }


    /// <summary>
    /// The AGBcode verijzer of the insured person.
    /// </summary>
    [MaxLength(20)]
    public string? AgbCodeVerwijzer { get; set; }

    /// <summary>
    /// The name of the referrer.
    /// </summary>
    [MaxLength(256)]
    public string? NaamVerwijzer { get; set; }

    /// <summary>
    /// The referral date.
    /// </summary>
    public DateTime? Verwijsdatum { get; set; }

    /// <summary>
    /// The status of the insured person.
    /// </summary>
    public Status Status { get; set; }


    /// <summary>
    /// Indicator if the insured person is shared with collegaues.
    /// </summary>
    public bool? Shared { get; set; }


    /// <summary>
    /// The time stamp of when the record has been created.
    /// </summary>
    public DateTime AangemaaktOp { get; set; }


    /// <summary>
    /// The unique identifier of the record creator.
    /// </summary>
    [Required]
    public Guid AangemaaktDoorId { get; set; }


    /// <summary>
    /// Name of the record creator.
    /// </summary>
    public string? AangemaaktDoor { get; set; }


    #region Navigation properties

    public Guid AdresboekId { get; set; }
    public virtual Adresboek Adresboek { get; set; }

    public Guid? AdresId { get; set; }
    public virtual Adres.Adres Adres { get; set; }

    public Guid? ZorgprofielId { get; set; }
    public virtual Zorgprofiel? Zorgprofiel { get; set; }

    public Guid? ZorgverzekeringId { get; set; }
    public virtual Zorgverzekering.Zorgverzekering Zorgverzekering { get; set; }

    public virtual ICollection<VerzekerdeToAdres> Adressen { get; set; } = new List<VerzekerdeToAdres>();
    public virtual ICollection<VerzekerdeToZorgprofiel> Zorgprofielen { get; set; } = new List<VerzekerdeToZorgprofiel>();
    public virtual ICollection<VerzekerdeToUser> Users { get; set; } = new List<VerzekerdeToUser>();
    public virtual ICollection<GliBehandelplan> GliBehandelplannen { get; set; } = new List<GliBehandelplan>();
    public virtual ICollection<GliIntake> GliIntakes { get; set; } = new List<GliIntake>();
    public virtual ICollection<VerzekerdeToZorgverzekering> Zorgverzekeringen { get; set; } = new List<VerzekerdeToZorgverzekering>();
    public virtual ICollection<Weegmoment> WeegMomenten { get; set; } = new List<Weegmoment>();
    public virtual ICollection<VerbruiksmiddelPrestatie> VerbruiksmiddelPrestaties { get; set; } = new List<VerbruiksmiddelPrestatie>();

    #endregion


    /// <summary>
    /// Creates an empty verzekerde
    /// </summary>
    public Verzekerde()
    {

    }

    /// <summary>
    /// Creates an verzekerde.
    /// </summary>
    /// <param name="cmd">The create verzekerde command.</param>
    public Verzekerde(CreateVerzekerde cmd)
    {
        Id = cmd.Id;

        AdresboekId = cmd.AdresboekId;
        Status = Status.Actief;
        Shared = false;

        Bsn = cmd.Bsn;
        Lengte = cmd.Lengte;
        cmd.Persoon.Voorletters = PersoonExtensions.VerwijderPunten(cmd.Persoon.Voorletters);
        cmd.Persoon.VolledigeNaam = PersoonExtensions.SetVolledigeNaam(cmd.Persoon.Voorletters, cmd.Persoon.Tussenvoegsel, cmd.Persoon.Achternaam, cmd.Persoon.Voornaam);
        Persoon = cmd.Persoon;

        Adres = cmd.Adres;
        Zorgverzekering = cmd.Zorgverzekering;
        Zorgprofiel = cmd.Zorgprofiel;

        AgbCodeVerwijzer = cmd.AgbCodeVerwijzer;
        NaamVerwijzer = cmd.NaamVerwijzer;
        Verwijsdatum = cmd.Verwijsdatum;

        AangemaaktOp = DateTime.Now;
        AangemaaktDoor = cmd.UserDisplayName;
        AangemaaktDoorId = cmd.UserId;
    }



    /// <summary>
    /// Update the details of the verzekerde.
    /// </summary>
    /// <param name="cmd">The update verzekerde command.</param>
    public void Update(UpdateVerzekerde cmd)
    {
        Bsn = cmd.Bsn;
        cmd.Persoon.Voorletters = PersoonExtensions.VerwijderPunten(cmd.Persoon.Voorletters);
        cmd.Persoon.FormeleNaam = PersoonExtensions.SetFormeleNaam(cmd.Persoon.Voorletters, cmd.Persoon.Tussenvoegsel, cmd.Persoon.Achternaam, cmd.Persoon.Voornaam);
        cmd.Persoon.VolledigeNaam = PersoonExtensions.SetVolledigeNaam(cmd.Persoon.Voorletters, cmd.Persoon.Tussenvoegsel, cmd.Persoon.Achternaam, cmd.Persoon.Voornaam);
        Persoon = cmd.Persoon;
        Adres = cmd.Adres;
        Zorgverzekering = cmd.Zorgverzekering;
        Zorgprofiel = cmd.Zorgprofiel;
        AgbCodeVerwijzer = cmd.AgbCodeVerwijzer;
        NaamVerwijzer = cmd.NaamVerwijzer;
        Verwijsdatum = cmd.Verwijsdatum;

    }



    /// <summary>
    /// Set the status as verzekerde.
    /// The verzekerde will no longer be visible.
    /// </summary>
    public void Delete()
    {
        Status = Status.Verwijderd;

        if (Zorgprofiel != null)
            Zorgprofiel = null;
    }

    /// <summary>
    /// Set the status as verzekerde.
    /// The verzekerde will be visible.
    /// </summary>
    public void Undelete()
    {
        Status = Status.Actief;
        Zorgprofiel = null;
    }


    /// <summary>
    /// Sets the status of the verzekerde as suspended.
    /// The verzekerde will no longer be available.
    /// </summary>
    public void Suspend()
    {
        Status = Status.Inactief;
    }

    /// <summary>
    /// Reinstates the verzekerde if suspended.
    /// </summary>
    public void Reinstate()
    {
        Status = Status.Actief;
    }


    /// <summary>
    /// Sets the status of the verzekerde with healthcare profile as suspended.
    /// The verzekerde will no longer be available.
    /// </summary>
    public void SuspendWithProfile(SuspendVerzekerdeMetZorgprofiel cmd)
    {
        Status = Status.Inactief;
        Zorgprofiel.ProfielEinddatum = cmd.ProfielEinddatum;
    }

    /// <summary>
    /// Reinstates the verzekerde with healthcare profile if suspended.
    /// </summary>
    public void ReinstateWithProfile(ReinstateVerzekerdeMetZorgprofiel cmd)
    {
        Status = Status.Actief;
        Zorgprofiel.ProfielStartdatum = cmd.ProfielStartdatum;
        Zorgprofiel.ProfielEinddatum = null;
    }


    /// <summary>
    /// Updates the lenght of the verzekerde.
    /// </summary>
    public void UpdateLength(double lengte)
    {
        Lengte = lengte;
    }

    /// <summary>
    /// Shares the verzekerde with a colleague.
    /// </summary>
    public void Share(AssingVerzekerde cmd)
    {
        Shared = cmd.Shared;
    }
}
