using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Private.Document;
using Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Models;
using Promeetec.EDMS.Reporting.Private.Document.Overigbestand.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Models;

public class AanleveringCreateViewModel : ModelBase
{
    public Guid Id { get; set; }

    public int Jaar { get; set; }

    [Display(Name = "Uw referentie")]
    [Required(ErrorMessage = "Uw referentie is verplicht.")]
    [StringLength(50, ErrorMessage = "{0} moet minimaal {2} en maximaal {1} tekens bevatten.", MinimumLength = 1)]
    public string Referentie { get; set; }


    [Display(Name = "Referentie Promeetec")]
    [StringLength(50, ErrorMessage = "{0} mag maximaal {1} tekens bevatten.")]
    public string ReferentiePromeetec { get; set; }


    [UIHint("Boolean")]
    [Display(Name = "Toevoegen documenten")]
    public bool ToevoegenBestand { get; set; }

    [AllowHtml]
    [Display(Name = "Opmerking")]
    [DataType(DataType.MultilineText)]
    [StringLength(4000, ErrorMessage = "{0} moet minimaal {2} en maximaal {1} tekens bevatten.", MinimumLength = 0)]
    public string Opmerking { get; set; }

    [Display(Name = "Aanleverstatus")]
    public AanleverStatus AanleverStatus { get; set; }

    public Status Status { get; set; }

    [UIHint("DateTime")]
    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [RegularExpression(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$", ErrorMessage = "Dit is geen geldige datum!")]
    public DateTime Aanleverdatum { get; set; }


    [UIHint("Date")]
    [DataType(DataType.Date)]
    [Display(Name = "Aangemaakt op")]
    public DateTime AangemaaktOp { get; set; }

    public Guid? AangemaaktDoor { get; set; }


    [UIHint("DateTime")]
    [DataType(DataType.Date)]
    [Display(Name = "Aangepast op")]
    public DateTime? AangepastOp { get; set; }

    public Guid? AangepastDoor { get; set; }


    [Display(Name = "Eigenaar")]
    [Required(ErrorMessage = "Eigenaar is verplicht.")]
    public Guid EigenaarId { get; set; }


    [Display(Name = "Eigenaar")]
    public SelectList Eigenaren { get; set; }

    public MedewerkerViewModel Eigenaar { get; set; }


    [Display(Name = "Behandelaar")]
    [Required(ErrorMessage = "Behandelaar is verplicht.")]
    public Guid? BehandelaarId { get; set; }

    public MedewerkerViewModel Behandelaar { get; set; }

    [Display(Name = "Behandelaar")]
    public SelectList Behandelaren { get; set; }


    public OrganisatieViewModel Organisatie { get; set; }


    public AanleverbestandenViewModel Aanleverbestanden { get; set; }

    public OverigbestandenViewModel Overigebestanden { get; set; }



    public FilesViewModel Files { get; set; } = new();

    public int AantalBerichten { get; set; }


    /// <summary>
    /// Deze property wordt gevuld via js. Als er een ongewone actie wordt uitgevoerd op de status van de aanlevering,
    /// dan kan de interne medewerker een vinkje aanzetten, om de eigenaar een status update te e-mailen.
    /// </summary>
    [HiddenInput(DisplayValue = false)]
    public bool VerzendEmailNaarEigenaar { get; set; }


    // Aanleverstatus id's van UserProfile eigenaar
    [HiddenInput(DisplayValue = false)]
    public string AanleverstatusIds { get; set; }


    [HiddenInput(DisplayValue = false)]
    public AanleverStatus OudeAanleverStatus { get; set; }


    [HiddenInput(DisplayValue = false)]
    public string HdnAanleverbestandenIds { get; set; }


    [HiddenInput(DisplayValue = false)]
    public string HdnOverigbestandenIds { get; set; }
}