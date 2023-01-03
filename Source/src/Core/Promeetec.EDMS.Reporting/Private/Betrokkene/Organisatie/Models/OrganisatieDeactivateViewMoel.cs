using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;

public class DeactivateOrganisatieViewModel : ModelBase
{
    [StringLength(450)]
    public string DeactivatieReden { get; set; }

}