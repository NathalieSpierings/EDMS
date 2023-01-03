using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Modules.Adresboek;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Adres.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;

public class OrganisatieModel : ModelBase
{

    public string Nummer { get; set; }
    public string Naam { get; set; }

    [Display(Name = "Telefoonnummer zakelijk"), DataType(DataType.PhoneNumber)]
    public string? TelefoonZakelijk { get; set; }

    [Display(Name = "Telefoonnummer privé"), DataType(DataType.PhoneNumber)]
    public string? TelefoonPrive { get; set; }

    [Display(Name = "E-mail"), EmailAddress]
    public string? Email { get; set; }

    [DataType(DataType.Url)]
    public string? Website { get; set; }

    [Display(Name = "AGB-code onderneming")]
    public string? AgbCodeOnderneming { get; set; }

    [Display(Name = "AGB-code onderneming")]
    public string AgbCodeOndernemingDisplay => AgbCodeOnderneming != null ? string.Concat("[", AgbCodeOnderneming.Replace(",", "]-["), "]") : "";

    public bool Zorggroep { get; set; }
    public Status Status { get; set; }
    public bool Beperkt { get; set; }

    [Display(Name = "Beperkt reden"), DataType(DataType.MultilineText)]
    public string? BeperktReden { get; set; }

    [Display(Name = "Beperkt op"), DataType(DataType.DateTime)]
    public DateTime BeperktOp { get; set; }


    [Display(Name = "Aanleverbestand schrijf locatie")]
    public string? AanleverbestandLocatie { get; set; }


    [Display(Name = "Aanleverstatus na automatisch wegschrijven aanleverbestanden")]
    public AanleverStatusNaSchrijvenAanleverbestanden AanleverStatusNaSchrijvenAanleverbestanden { get; set; }


    [Display(Name = "Verwijzer in adresboek")]
    public VerwijzerInAdresboekType VerwijzerInAdresboek { get; set; }

    public DateTime? VerwijderdOp { get; set; }
    public Guid? VerwijderdDoorId { get; set; }
    public string? VerwijderdDoor { get; set; }

 
    public Guid? ZorggroepRelatieId { get; set; }

    [Display(Name = "Zorggroep relatie")]
    public string? ZorggroepRelatie { get; set; }


    public Guid? ContactpersoonId { get; set; }

    [Display(Name = "Contactpersoon")]
    public string? ContactpersoonVolledigeNaam { get; set; }

    [EmailAddress]
    [Display(Name = "E-mail contactpersoon")]
    public string ContactpersoonEmail { get; set; }


    [Display(Name = "Telefoonnummer contactpersoon")]
    [DataType(DataType.PhoneNumber)]
    public string? ContactpersoonTelefoon { get; set; }


 //   [UIHint("Adres")]
    public AdresModel Adres { get; set; }

    public Guid AdresboekId { get; set; }


    [Display(Name = "Organisatie")]
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
    
    public GekoppeldeOrganisatiesModel GekoppeldeOrganisaties { get; set; }
}