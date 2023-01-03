using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;

public class DeactivateMedewerkerViewModel
{
    [StringLength(450)]
    public string DeactivatieReden { get; set; }

}