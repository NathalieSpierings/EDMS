using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;
using Promeetec.EDMS.Portaal.Reporting.Shared.Models;

namespace Promeetec.EDMS.Portaal.Reporting.Private.Betrokkene.Land.Models;

public class LandModel : ModelBase
{

    [Display(Name = "Naam")]
    public string? NativeName { get; set; }

    [Display(Name = "Culture code")]
    public string CultureCode { get; set; }

    public Status Status { get; set; }
}