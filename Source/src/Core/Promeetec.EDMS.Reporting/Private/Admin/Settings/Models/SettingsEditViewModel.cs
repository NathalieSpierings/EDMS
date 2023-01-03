using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.Settings.Models;

public class SettingsEditViewModel : ModelBase
{
    [Display(Name = "Bedrag basis verzekering haarwerk")]
    public decimal BedragBasisVerzekeringHaarwerk { get; set; }
}
