using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Portaal.Core.Domain;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Rapportage;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Adresboek;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Haarwerk;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie;

public class Organisatie : AggregateRoot
{
   
    /// <summary>
    /// The number of the organisatie.
    /// </summary>
    [Required, MaxLength(50)]
    public string Nummer { get; set; }

    /// <summary>
    /// The name of the organisatie.
    /// </summary>
    [Required, MaxLength(200)]
    public string Naam { get; set; }

    /// <summary>
    /// The business phonenumber of the organisatie.
    /// </summary>
    [MaxLength(50)]
    public string? TelefoonZakelijk { get; set; }

    /// <summary>
    /// The private phonenumber of the organisatie.
    /// </summary>
    [MaxLength(50)]
    public string? TelefoonPrive { get; set; }

    /// <summary>
    /// The e-mail address for the organisatie.
    /// </summary>
    [MaxLength(450)]
    public string? Email { get; set; }

    /// <summary>
    /// The website for the organisatie.
    /// </summary>
    [MaxLength(450)]
    public string? Website { get; set; }

    /// <summary>
    /// The vektis agbcode for the organisatie.
    /// </summary>
    [MaxLength(200)]
    public string? AgbCodeOnderneming { get; set; }

    /// <summary>
    /// Value indicating whether the organisatie is a zorgroep or not.
    /// </summary>
    public bool Zorggroep { get; set; }

    /// <summary>
    /// The status of the organisatie.
    /// </summary>
    public Status Status { get; set; }

    /// <summary>
    /// Value indicating whether the organisatie is blocked.
    /// When an organisatie is limitid, the members of this organisatie have readonly rights.
    /// </summary>
    public bool Beperkt { get; set; }

    /// <summary>
    /// The reason why the organisatie is limitid.
    /// </summary>
    [MaxLength(450)]
    public string? BeperktReden { get; set; }


    /// <summary>
    /// The preferences of the organisatie.
    /// </summary>
    public OrganisatieSettings Settings { get; set; }


    /// <summary>
    /// The date the Status has been set to Verwijderd.
    /// </summary>
    public DateTime? VerwijderdOp { get; set; }

    /// <summary>
    /// The unique identifier of the deleter.
    /// </summary>
    public Guid? VerwijderdDoorId { get; set; }

    /// <summary>
    /// The name of the deleter.
    /// </summary>
    public string? VerwijderdDoor { get; set; }


    public string? DisplayName => !string.IsNullOrEmpty(Nummer) ? $"{Naam} ({Nummer})" : $"{Naam}";

    public bool IsPromeetec
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(Nummer))
            {
                if (Nummer == "0000")
                    return true;
            }

            return false;
        }
    }


    #region Navigation properties

    public Guid? ZorggroepRelatieId { get; set; }
    public virtual Organisatie ZorggroepRelatie { get; set; }

    public Guid? ContactpersoonId { get; set; }
    public virtual Medewerker.Medewerker Contactpersoon { get; set; }

    public Guid? AdresId { get; set; }
    public virtual Adres.Adres Adres { get; set; }

    public Guid AdresboekId { get; set; }
    public virtual Adresboek Adresboek { get; set; }

    public virtual ICollection<Medewerker.Medewerker> Medewerkers { get; set; }
    public virtual ICollection<Aanlevering> Aanleveringen { get; set; }
    public virtual ICollection<Haarwerk> HaarwerkPrestaties { get; set; }
    public virtual ICollection<Rapportage> Rapportages { get; set; }
    public virtual ICollection<GliIntake> GliIntakes { get; set; }
    public virtual ICollection<GliBehandelplan> GliBehandelplannen { get; set; }
    public virtual ICollection<VerbruiksmiddelPrestatie> VerbruiksmiddelPrestaties { get; set; }

    #endregion


    /// <summary>
    /// Creates an empty organisatie.
    /// </summary>
    public Organisatie()
    {
    }


    /// <summary>
    /// Creates an organisatie.
    /// </summary>
    /// <param name="cmd">The create organisatie command.</param>
    public Organisatie(CreateOrganisatie cmd)
    {
        Id = cmd.Id;
        Status = Status.Inactief;
        Nummer = cmd.Nummer;
        Naam = cmd.Naam;
        TelefoonZakelijk = cmd.TelefoonZakelijk;
        TelefoonPrive = cmd.TelefoonPrive;
        Email = cmd.Email;
        Website = cmd.Website;
        AgbCodeOnderneming = cmd.AgbCodeOnderneming;
        Zorggroep = cmd.Zorggroep;
        Settings = cmd.Settings;
        ZorggroepRelatieId = cmd.ZorggroepRelatieId;
        ContactpersoonId = cmd.ContactpersoonId;
        AdresId = cmd.AdresId;
        AdresboekId = cmd.AdresboekId;
    }

    /// <summary>
    /// Update the details of the organisatie.
    /// </summary>
    /// <param name="cmd">The update organisatie command.</param>
    public void Update(UpdateOrganisatie cmd)
    {
        Naam = cmd.Naam;
        TelefoonZakelijk = cmd.TelefoonZakelijk;
        TelefoonPrive = cmd.TelefoonPrive;
        Email = cmd.Email;
        Website = cmd.Website;
        AgbCodeOnderneming = cmd.AgbCodeOnderneming;
        Zorggroep = cmd.Zorggroep;
        Settings = cmd.Settings;
        ZorggroepRelatieId = cmd.ZorggroepRelatieId;
        ContactpersoonId = cmd.ContactpersoonId;
        AdresId = cmd.AdresId;
    }

    /// <summary>
    /// Sets the organisatie as restricted.
    /// The organisatie users have only read-only rights.
    /// </summary>
    public void Restrict(string beperktReden)
    {
        Beperkt = true;
        BeperktReden = beperktReden;
    }

    /// <summary>
    /// Sets the organisatie as restricted.
    /// The organisatie users have only read-only rights.
    /// </summary>
    public void Unrestrict()
    {
        Beperkt = false;
        BeperktReden = null;
    }


    /// <summary>
    /// Sets the status of the organisatie as suspended.
    /// The organisatie users will no longer be able to login.
    /// </summary>
    public void Suspend()
    {
        Status = Status.Inactief;
    }

    /// <summary>
    /// Reinstate the organisatie if suspended.
    /// </summary>
    public void Reinstate()
    {
        Status = Status.Actief;
    }

    /// <summary>
    /// Set the status as deleted.
    /// The organisatie will no longer be visible.
    /// </summary>
    public void Delete()
    {
        Status = Status.Verwijderd;
    }
}
