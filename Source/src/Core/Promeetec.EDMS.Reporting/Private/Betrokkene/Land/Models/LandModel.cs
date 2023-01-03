using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Land.Models;

public class LandModel : ModelBase
{

    [Display(Name = "Naam")]
    public string? NativeName { get; set; }

    [Display(Name = "Culture code")]
    public string CultureCode { get; set; }

    public Status Status { get; set; }
}