using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Land.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Adres.Models;

public class AdresCreateEditViewModel : ModelBase
{
    public Guid Id { get; set; }

    [StringLength(200, ErrorMessage = "{0} kan maximaal {1} tekens bevatten.")]
    public string Straat { get; set; }



    // NL, BE, DE postcode regex
    [RegularExpression(@"^\d{4}\s?\w{2}$|^(?:(?:[1-9])(?:\d{3}))$|^\d{5}$", ErrorMessage = "Alleen postcodes uit NL, BE of DE zijn toegestaan.")]
    public string Postcode { get; set; }


    [StringLength(20, ErrorMessage = "{0} kan maximaal {1} tekens bevatten.")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "Huisnummer moet numeriek zijn.")]
    public string Huisnummer { get; set; }


    [Display(Name = "Huisnr. toevoeging")]
    [StringLength(20, ErrorMessage = "{0} kan maximaal {1} tekens bevatten.")]
    public string HuisnummerToevoeging { get; set; }

    [StringLength(200, ErrorMessage = "{0} kan maximaal {1} tekens bevatten.")]
    public string Woonplaats { get; set; }


    [UIHint("Date")]
    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [RegularExpression(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$", ErrorMessage = "Dit is geen geldige datum!")]
    [Display(Name = "Woonachtig op")]
    public DateTime? WoonachtigOp { get; set; }


    [UIHint("Date")]
    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [RegularExpression(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$", ErrorMessage = "Dit is geen geldige datum!")]
    [Display(Name = "Woonachtig op")]
    public DateTime? WoonachtigTot { get; set; }

    [Display(Name = "Land")]
    [Required(ErrorMessage = "Land is verplicht.")]
    public Guid LandId { get; set; }

    public LandCreateViewModel Land { get; set; }

    [Display(Name = "Land")]
    public SelectList Landen { get; set; }
}