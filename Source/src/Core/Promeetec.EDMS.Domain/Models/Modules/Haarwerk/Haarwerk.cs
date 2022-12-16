using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Modules.Haarwerk.Commands;

namespace Promeetec.EDMS.Domain.Models.Modules.Haarwerk;

public class Haarwerk : AggregateRoot
{
    /// <summary>
    /// The name of the client.
    /// </summary>
    [Required, MaxLength(200)]
    public string Naam { get; set; }

    /// <summary>
    /// The date of birth of the client.
    /// </summary>
    [Required]
    public DateTime Geboortedatum { get; set; }

    /// <summary>
    /// The BSN of the client.
    /// </summary>
    [Required, MaxLength(20)]
    public string Bsn { get; set; }

    /// <summary>
    /// The optional insurance number of the client.
    /// </summary>
    [MaxLength(50)]
    public string? Verzekeringsnummer { get; set; }

    /// <summary>
    /// The optional machtigings number.
    /// </summary>
    [MaxLength(50)]
    public string? Machtigingsnummer { get; set; }

    /// <summary>
    /// The kind of hulpmiddel.
    /// </summary>
    [Required]
    public HaarwerkTypeHulpmiddel TypeHulpmiddel { get; set; }


    /// <summary>
    /// The kind of delivery.
    /// </summary>
    [Required]
    public HaarwerkLeveringSoort LeveringSoort { get; set; }


    /// <summary>
    /// The kind of haarwerk.
    /// </summary>
    [Required]
    public HaarwerkSoort HaarwerkSoort { get; set; }


    /// <summary>
    /// The delivery date.
    /// </summary>
    [Required]
    public DateTime Afleverdatum { get; set; }

    /// <summary>
    /// The date of the previous hulpmiddel.
    /// </summary>
    public DateTime? DatumVoorgaandHulpmiddel { get; set; }


    /// <summary>
    /// The date of the medical prescription.
    /// </summary>
    public DateTime? DatumMedischVoorschrift { get; set; }

    /// <summary>
    /// The price of the haarwerk.
    /// </summary>
    [Column(TypeName = "decimal(18, 2)")]
    public decimal PrijsHaarwerk { get; set; }

    /// <summary>
    /// The amount of the basic insurance.
    /// </summary>
    [Column(TypeName = "decimal(18, 2)")]
    public decimal BedragBasisVerzekering { get; set; }

    /// <summary>
    /// The amount of the additional insurance.
    /// </summary>
    [Column(TypeName = "decimal(18, 2)")]
    public decimal BedragAanvullendeVerzekering { get; set; }

    /// <summary>
    /// The amount of the contribution (paid by client).
    /// </summary>
    [Column(TypeName = "decimal(18, 2)")]
    public decimal BedragEigenBijdragen { get; set; }

    /// <summary>
    /// The amount wanted to recieve of the insurance company.
    /// </summary>
    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal BedragTeOntvangen { get; set; }

    /// <summary>
    /// The status of the prestatie.
    /// </summary>
    [Required]
    public HaarwerkStatus Status { get; set; }

    /// <summary>
    /// Indicator whether it concerns a credit.
    /// </summary>
    public HaarwerkCreditType CreditType { get; set; }

    /// <summary>
    /// Indicator when the records have been exported.
    /// </summary>
    public DateTime? ExportedOn { get; set; }


    #region Navigation properties

    public Guid OrganisatieId { get; set; }
    public Organisatie Organisatie { get; set; }

    #endregion



    /// <summary>
    /// Creates an empty addressbook.
    /// </summary>
    public Haarwerk()
    {

    }

    /// <summary>
    /// Creates an haarwerk registratie.
    /// </summary>
    /// <param name="cmd">The create haarwerk command.</param>
    public Haarwerk(CreateHaarwerk cmd)
    {
        Id = cmd.Id;

        OrganisatieId = cmd.OrganisatieId;
        Naam = cmd.Naam;
        Geboortedatum = cmd.Geboortedatum;
        Bsn = cmd.Bsn;
        Verzekeringsnummer = cmd.Verzekeringsnummer;
        Machtigingsnummer = cmd.Machtigingsnummer;
        TypeHulpmiddel = cmd.TypeHulpmiddel;
        LeveringSoort = cmd.LeveringSoort;
        HaarwerkSoort = cmd.HaarwerkSoort;
        Afleverdatum = cmd.Afleverdatum;
        DatumVoorgaandHulpmiddel = cmd.DatumVoorgaandHulpmiddel;
        DatumMedischVoorschrift = cmd.DatumMedischVoorschrift;
        PrijsHaarwerk = cmd.PrijsHaarwerk;
        BedragBasisVerzekering = cmd.BedragBasisVerzekering;
        BedragAanvullendeVerzekering = cmd.BedragAanvullendeVerzekering;
        BedragEigenBijdragen = cmd.BedragEigenBijdragen;
        BedragTeOntvangen = cmd.BedragTeOntvangen;
        Status = HaarwerkStatus.Nieuw;
        CreditType = HaarwerkCreditType.None;
    }


    /// <summary>
    /// Update the details of the haarwerk registratie.
    /// </summary>
    /// <param name="cmd">The update haarwerk command.</param>
    public void Update(UpdateHaarwerk cmd)
    {
        Naam = cmd.Naam;
        Geboortedatum = cmd.Geboortedatum;
        Bsn = cmd.Bsn;
        Verzekeringsnummer = cmd.Verzekeringsnummer;
        Machtigingsnummer = cmd.Machtigingsnummer;
        TypeHulpmiddel = cmd.TypeHulpmiddel;
        LeveringSoort = cmd.LeveringSoort;
        HaarwerkSoort = cmd.HaarwerkSoort;
        Afleverdatum = cmd.Afleverdatum;
        DatumVoorgaandHulpmiddel = cmd.DatumVoorgaandHulpmiddel;
        DatumMedischVoorschrift = cmd.DatumMedischVoorschrift;
        PrijsHaarwerk = cmd.PrijsHaarwerk;
        BedragBasisVerzekering = cmd.BedragBasisVerzekering;
        BedragAanvullendeVerzekering = cmd.BedragAanvullendeVerzekering;
        BedragEigenBijdragen = cmd.BedragEigenBijdragen;
        BedragTeOntvangen = cmd.BedragTeOntvangen;
        Status = HaarwerkStatus.Nieuw;
        CreditType = cmd.CreditType;
    }


    /// <summary>
    /// Credits the haarwerk registratie.
    /// </summary>
    /// <param name="cmd">The credit haarwerk command.</param>
    public void Credit(CreditHaarwerk cmd)
    {
        OrganisatieId = cmd.OrganisatieId;
        Naam = cmd.Naam;
        Geboortedatum = cmd.Geboortedatum;
        Bsn = cmd.Bsn;
        Verzekeringsnummer = cmd.Verzekeringsnummer;
        Machtigingsnummer = cmd.Machtigingsnummer;
        TypeHulpmiddel = cmd.TypeHulpmiddel;
        LeveringSoort = cmd.LeveringSoort;
        HaarwerkSoort = cmd.HaarwerkSoort;
        Afleverdatum = cmd.Afleverdatum;
        DatumVoorgaandHulpmiddel = cmd.DatumVoorgaandHulpmiddel;
        DatumMedischVoorschrift = cmd.DatumMedischVoorschrift;
        PrijsHaarwerk = cmd.PrijsHaarwerk;
        BedragBasisVerzekering = cmd.BedragBasisVerzekering;
        BedragAanvullendeVerzekering = cmd.BedragAanvullendeVerzekering;
        BedragEigenBijdragen = cmd.BedragEigenBijdragen;
        BedragTeOntvangen = cmd.BedragTeOntvangen;
        Status = HaarwerkStatus.Nieuw;
        CreditType = HaarwerkCreditType.Credit;
    }
}