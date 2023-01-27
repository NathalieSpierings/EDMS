using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Promeetec.EDMS.Portaal.Domain.Models.Admin.Settings;

[Owned]
public class SettingsHaarwerk
{
    /// <summary>
    /// The amount of the basic insurance.
    /// </summary>
    [Required, Column(TypeName = "decimal(18, 2)")]
    public decimal BedragBasisVerzekeringHaarwerk { get; set; }
}
