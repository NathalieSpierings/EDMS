using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Land.Models;

public class LandCreateViewModel : ModelBase
{
    [Required(ErrorMessage = "{0} is verplicht.")]
    [Display(Name = "Naam")]
    public string NativeName { get; set; }


    [Required(ErrorMessage = "{0} is verplicht.")]
    [Display(Name = "Culture code")]
    public string CultureCode { get; set; }
}