using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Reporting.Attributes;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Adres.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Persoon.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Verbruiksmiddel.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Models;

public class VerzekerdeCreateViewModel : ModelBase
{
    public Guid Id { get; set; }
    public Guid AdresboekId { get; set; }
    public Status Status { get; set; }
    public bool Shared { get; set; }

    [Display(Name = "Burgerservicenummer")]
    [Required(ErrorMessage = "Burgerservicenummer is verplicht.")]
    public string Bsn { get; set; }

    [Display(Name = "Lengte")]
    public double? Lengte { get; set; }

    public OrganisatieViewModel Organisatie { get; set; }

    [RequiredWhenVerwijzerInAdresboek]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "AGB-code verwijzer bestaat uit 8 cijfers!")]
    [Display(Name = "AGB-code verwijzer")]
    public string AgbCodeVerwijzer { get; set; }


    [Display(Name = "Naam verwijzer")]
    [StringLength(256)]
    public string NaamVerwijzer { get; set; }

    [RequiredWhenVerwijsDatumInAdresboek]
    [UIHint("Date")]
    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [RegularExpression(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$", ErrorMessage = "Dit is geen geldige datum!")]
    public DateTime? Verwijsdatum { get; set; }


    [UIHint("Date")]
    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [RegularExpression(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$", ErrorMessage = "Dit is geen geldige datum!")]
    [Required(ErrorMessage = "Geboortedatum is verplicht.")]
    [Remote("IsGeboortedatumValid", "Adresboek", ErrorMessage = "{0} kan niet in de toekomst liggen.", HttpMethod = "POST")]
    public DateTime Geboortedatum { get; set; }







    public PersoonCreateEditViewModel Persoon { get; set; }
    public AdresCreateEditViewModel Adres { get; set; }
    public ZorgverzekeringCreateViewModel Zorgverzekering { get; set; }
    public ZorgprofielViewModel Zorgprofiel { get; set; }


    [UIHint("DateTime")]
    [DataType(DataType.Date)]
    [Display(Name = "Aangemaakt op")]
    public DateTime AangemaaktOp { get; set; }

    public Guid AangemaaktDoorId { get; set; }


    [Display(Name = "Aangemaakt door")]
    public string AangemaaktDoor { get; set; }


    [Display(Name = "Collega's")]
    public MultiSelectList SelectListCollegas { get; set; }

    public List<Guid> CollegaIds { get; set; }


}