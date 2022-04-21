using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.UserProfile;

public enum EmailOntvangenType
{
    Nee = 1,

    [Display(Name = "Alleen van mijn aanleveringen")]
    Eigen = 2,

    [Display(Name = "Van alle aanleveringen")]
    Alle = 3
}
