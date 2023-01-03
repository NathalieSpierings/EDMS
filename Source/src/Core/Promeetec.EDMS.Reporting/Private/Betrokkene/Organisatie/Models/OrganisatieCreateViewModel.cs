using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.COV;
using Promeetec.EDMS.Domain.Models.Modules.Adresboek;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Domain.Models.Modules.ION;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Adres.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;

public class OrganisatieCreateViewModel : ModelBase
{
    [Remote("IsNummerUnique", "Organisatie", AdditionalFields = "Id", ErrorMessage = "{0} moet uniek zijn.", HttpMethod = "POST")]
    [Required(ErrorMessage = "{0} is verplicht.")]
    [StringLength(20, ErrorMessage = "{0} kan maximaal {1} tekens bevatten.")]
    public string Nummer { get; set; }


    [Required(ErrorMessage = "{0} is verplicht.")]
    [StringLength(200, ErrorMessage = "{0} kan maximaal {1} tekens bevatten.")]
    public string Naam { get; set; }


    [Display(Name = "Organisatie")]
    public string DisplayName => !string.IsNullOrEmpty(Nummer) ? $"{Naam} ({Nummer})" : $"{Naam}";

    [Required(ErrorMessage = "AGB-code onderneming is verplicht.")]
    [Display(Name = "AGB-code onderneming")]
    [StringLength(50, MinimumLength = 7, ErrorMessage = "AGB-code onderneming bestaat uit 8 cijfers!")]
    public string AgbCodeOnderneming { get; set; }

    [UIHint("Boolean")]
    [DefaultValue(false)]
    public bool Zorggroep { get; set; }



    [Display(Name = "Telefoonnummer zakelijk")]
    [DataType(DataType.PhoneNumber, ErrorMessage = "Dit is geen geldig telefoonnummer!")]
    [StringLength(15, ErrorMessage = "{0} moet minstens {2} cijfers bevatten en mag niet langer zijn dan {1} cijfers.", MinimumLength = 10)]
    public string Telefoon { get; set; }


    [Display(Name = "Telefoonnummer privé")]
    [DataType(DataType.PhoneNumber, ErrorMessage = "Dit is geen geldig telefoonnummer!")]
    [StringLength(15, ErrorMessage = "{0} moet minstens {2} cijfers bevatten en mag niet langer zijn dan {1} cijfers.", MinimumLength = 10)]
    public string Telefoon1 { get; set; }


    [Display(Name = "E-mail")]
    [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "Dit is geen geldig e-mailadres!")]
    [EmailAddress(ErrorMessage = "Dit is geen geldig e-mailadres!")]
    [StringLength(450, ErrorMessage = "{0} moet minimaal {2} en maximaal {1} tekens bevatten.", MinimumLength = 6)]
    public string Email { get; set; }


    [UIHint("Url")]
    [DataType(DataType.Url)]
    [Url(ErrorMessage = "Dit is geen geldig webadres. Een webadres bevat tenminste http:// of https:// ")]
    [StringLength(256, ErrorMessage = "{0} moet minimaal {2} en maximaal {1} tekens bevatten.", MinimumLength = 9)]
    public string Website { get; set; }


    [Display(Name = "Aanleverbestand schrijf locatie")]
    public string AanleverbestandLocatie { get; set; }


    [Display(Name = "Aanleverstatus na automatisch wegschrijven aanleverbestanden")]
    public AanleverStatusNaSchrijvenAanleverbestanden AanleverStatusNaSchrijvenAanleverbestanden { get; set; }


    [Display(Name = "COV controle")]
    public COVControleType COVControleType { get; set; }


    [Display(Name = "COV controle procedure")]
    public COVControleProcessType COVControleProcessType { get; set; }


    [Display(Name = "Patientrelaties zoekoptie")]
    public IONZoekOptie IONZoekoptie { get; set; }


    [Display(Name = "Verwijzer in adresboek")]
    public VerwijzerInAdresboekType VerwijzerInAdresboek { get; set; }


    [Display(Name = "Zorggroep relatie")]
    public Guid? ZorggroepRelatieId { get; set; }

    [Display(Name = "Zorggroep relatie")]
    public SelectList ZorggroepRelaties { get; set; }


    [Display(Name = "Contactpersoon")]
    [Required(ErrorMessage = "Contactpersoon is verplicht.")]
    public Guid? ContactpersoonId { get; set; }

    [Display(Name = "Contactpersoon")]
    public SelectList Contactpersonen { get; set; }

    public AdresViewModel Adres { get; set; }

}