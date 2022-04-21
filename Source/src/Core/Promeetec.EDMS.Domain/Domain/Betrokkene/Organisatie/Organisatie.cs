using Promeetec.EDMS.Domain.Domain.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Domain.Domain.COV;
using Promeetec.EDMS.Domain.Domain.Document.Rapportage;
using Promeetec.EDMS.Domain.Domain.Modules.Adresboek;
using Promeetec.EDMS.Domain.Domain.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Domain.Domain.Modules.Declaratie.Voorraad;
using Promeetec.EDMS.Domain.Domain.Modules.GLI.Intake;
using Promeetec.EDMS.Domain.Domain.Modules.ION;
using Promeetec.EDMS.Domain.Domain.Modules.Verbruiksmiddelen.Verbruiksmiddel;
using Promeetec.EDMS.Domain.Domain.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promeetec.EDMS.Domain.Domain.Betrokkene.Organisatie;

public class Organisatie
{
    /// <summary>
    /// The unique identifier of the site.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// The number of the organisatie.
    /// </summary>
    [StringLength(50)]
    public string Nummer { get; private set; }


    /// <summary>
    /// The name of the organisatie.
    /// </summary>
    [StringLength(200)]
    public string Naam { get; private set; }

    /// <summary>
    /// The business phonenumber of the organisatie.
    /// </summary>
    [MaxLength(50)]
    public string TelefoonZakelijk { get; private set; }


    /// <summary>
    /// The private phonenumber of the organisatie.
    /// </summary>
    [MaxLength(50)]
    public string TelefoonPrive { get; private set; }

    /// <summary>
    /// The e-mail address for the organisatie.
    /// </summary>
    [StringLength(450)]
    public string Email { get; private set; }


    /// <summary>
    /// The website for the organisatie.
    /// </summary>
    [StringLength(450)]
    public string Website { get; private set; }


    /// <summary>
    /// The vektis agbcode for the organisatie.
    /// </summary>
    [StringLength(200)]
    public string AgbCodeOnderneming { get; private set; }


    /// <summary>
    /// Value indicating whether the organisatie is a zorgroep or not.
    /// </summary>
    public bool Zorggroep { get; private set; }


    /// <summary>
    /// The logo of for the organisatie.
    /// </summary>
    [MaxLength]
    [Column(TypeName = "varbinary(max)")]
    public byte[] Logo { get; private set; }


    /// <summary>
    /// The status of the organisatie.
    /// <list type="bullet">
    /// <item>
    /// <description>Inactief: Medewerker of this organisatie cannot login.</description>
    /// </item>
    /// <item>
    /// <description>Actief: Medewerker of this organisatie can login.</description>
    /// </item>
    /// <item>
    /// <description>Verwijderd: Organisatie is soft deleted.</description>
    /// </item>
    /// </list>
    /// </summary>
    public Status Status { get; private set; }

    /// <summary>
    /// Value indicating whether the organisatie is blocked.
    /// When an organisatie is limitid, the members of this organisatie have readonly rights.
    /// </summary>
    public bool Beperkt { get; private set; }


    /// <summary>
    /// The reason why the organisatie is limitid.
    /// </summary>
    [StringLength(450)]
    public string BeperktReden { get; private set; }

    /// <summary>
    /// The ION search option for the organisatie.
    /// </summary>
    public IONZoekOptie IONZoekoptie { get; private set; }


    /// <summary>
    /// The aanleverbestand location for the organisatie.
    /// </summary>
    public string AanleverbestandLocatie { get; private set; }


    /// <summary>
    /// The aanleverstatus after writing aanleverbestanden for the organisatie.
    /// </summary>
    public AanleverStatusNaSchrijvenAanleverbestanden AanleverStatusNaSchrijvenAanleverbestanden { get; private set; }


    /// <summary>
    /// The COV controle type for the organisatie.
    /// </summary>
    public COVControleType COVControleType { get; private set; }


    /// <summary>
    /// The COV controle process type for the organisatie.
    /// </summary>
    public COVControleProcessType COVControleProcessType { get; private set; }

    /// <summary>
    /// The time stamp of when the record has been created.
    /// </summary>
    public DateTime TimeStamp { get; private set; }


    #region Navigation properties


    /// <summary>
    /// The unique identifier of the zorggroep relatie for the organisatie.
    /// </summary>
    public Guid? ZorggroepRelatieId { get; private set; }

    /// <summary>
    /// Reference to the zorggroep for the organisatie.
    /// </summary>
    public Organisatie ZorggroepRelatie { get; set; }



    /// <summary>
    /// The unique identifier of the contactpersoon for this organisatie.
    /// </summary>
    public Guid? ContactpersoonId { get; private set; }

    /// <summary>
    /// Reference to the medewerker who is the contactpersoon the organisatie.
    /// </summary>
    public Medewerker.Medewerker Contactpersoon { get; set; }



    /// <summary>
    /// The unique identifier of the adres for the organisatie.
    /// </summary>
    public Guid? AdresId { get; private set; }

    /// <summary>
    /// Reference to the address for the organisatie.
    /// </summary>
    public Adres.Adres Adres { get; set; }

    /// <summary>
    /// The unique identifier of the voorraad for the organisatie.
    /// </summary>
    public Guid VoorraadId { get; set; }

    /// <summary>
    /// Reference to the voorraad for the organisatie.
    /// </summary>
    public Voorraad Voorraad { get; set; }


    /// <summary>
    /// The unique identifier of the adresbook for the organisatie.
    /// </summary>
    public Guid AdresboekId { get; set; }

    /// <summary>
    /// Reference to the addressbook for the organisatie.
    /// </summary>
    public Adresboek Adresboek { get; set; }

    public ICollection<Medewerker.Medewerker> Medewerkers { get; set; } = new List<Medewerker.Medewerker>();
    public ICollection<Aanlevering> Aanleveringen { get; set; } = new List<Aanlevering>();
    public ICollection<Rapportage> Rapportages { get; set; } = new List<Rapportage>();
    public ICollection<GliIntake> GliIntakes { get; set; } = new List<GliIntake>();
    public ICollection<IONPatientRelatie> IONPatientRelaties { get; set; } = new List<IONPatientRelatie>();
    public ICollection<VerbruiksmiddelPrestatie> VerbruiksmiddelPrestaties { get; set; } = new List<VerbruiksmiddelPrestatie>();

    #endregion


    public string DisplayName => !string.IsNullOrEmpty(Nummer) ? $"{Naam} ({Nummer})" : $"{Naam}";
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


    /// <summary>
    /// Creates an empty organisatie.
    /// </summary>
    public Organisatie()
    {
    }

    /// <summary>
    /// Creates a new organisatie with the given values.
    /// </summary>
    public Organisatie(CreateOrganisatie cmd)
    {
        Id = Guid.NewGuid();
        Nummer = cmd.Nummer;
        Naam = cmd.Naam;
        TelefoonZakelijk = cmd.TelefoonZakelijk;
        TelefoonPrive = cmd.TelefoonPrive;
        Email = cmd.Email;
        Website = cmd.Website;
        AgbCodeOnderneming = cmd.AgbCodeOnderneming;
        Zorggroep = cmd.Zorggroep;
        Logo = cmd.Logo;
        IONZoekoptie = cmd.IONZoekoptie;
        AanleverbestandLocatie = cmd.AanleverbestandLocatie;
        AanleverStatusNaSchrijvenAanleverbestanden = cmd.AanleverStatusNaSchrijvenAanleverbestanden;
        COVControleType = cmd.COVControleType;
        COVControleProcessType = cmd.COVControleProcessType;
    }


    /// <summary>
    /// Updates the details of the organisaatie.
    /// </summary>
    public void UpdateDetails(UpdateOrganisatie cmd)
    {
        Naam = cmd.Naam;
        TelefoonZakelijk = cmd.TelefoonZakelijk;
        TelefoonPrive = cmd.TelefoonPrive;
        Email = cmd.Email;
        Website = cmd.Website;
        AgbCodeOnderneming = cmd.AgbCodeOnderneming;
        Zorggroep = cmd.Zorggroep;
        Logo = cmd.Logo;
        IONZoekoptie = cmd.IONZoekoptie;
        AanleverbestandLocatie = cmd.AanleverbestandLocatie;
        AanleverStatusNaSchrijvenAanleverbestanden = cmd.AanleverStatusNaSchrijvenAanleverbestanden;
        COVControleType = cmd.COVControleType;
        COVControleProcessType = cmd.COVControleProcessType;
    }
}
