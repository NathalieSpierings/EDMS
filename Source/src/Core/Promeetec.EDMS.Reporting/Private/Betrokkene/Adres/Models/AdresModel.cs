using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Land.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Adres.Models;

public class AdresModel : ModelBase
{
    public string Straat { get; set; }
    public string Postcode { get; set; }
    public string Huisnummer { get; set; }

    [Display(Name = "Huisnr. toevoeging")]
    public string? HuisnummerToevoeging { get; set; }

    public string Woonplaats { get; set; }

    [Display(Name = "Land")]
    public string? LandNaam { get; set; }


    public Guid? LandId { get; set; }

    [Display(Name = "Land")]
    public LandModel? Land { get; set; }

    [DataType(DataType.Date)]
    public DateTime? WoonachtigOp { get; set; }

    [DataType(DataType.Date)]
    public DateTime? WoonachtigTot { get; set; }


    [Display(Name = "Adres")]
    public string? VektisVolledigeAdres => AdresExtensions.VolledigeAdres(Straat, Huisnummer, HuisnummerToevoeging, Postcode, Woonplaats, LandNaam);

    [Display(Name = "Adres")]
    public string? VolledigeAdres => AdresExtensions.VolledigeAdres(Straat, Huisnummer, HuisnummerToevoeging, Postcode, Woonplaats, Land?.NativeName);

    [Display(Name = "Land")]
    public SelectList Landen { get; set; }
}