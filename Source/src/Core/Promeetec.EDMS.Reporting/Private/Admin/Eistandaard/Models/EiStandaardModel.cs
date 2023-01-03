using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.Eistandaard.Models;

public class EiStandaardModel : ModelBase
{
    public string Naam { get; set; }

    [Display(Name = "EI bericht codes")]
    public string EiBerichtCodes { get; set; }

    public int? Versie { get; set; }
    public int? Subversie { get; set; }
    public string Code { get; set; }
    
    [DataType(DataType.MultilineText)]
    public string Omschrijving { get; set; }
}