using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Models.Modules.Haarwerk;

public enum HaarwerkCreditType
{
    [Display(Name = "Geen creditering")]
    None = 0,

    [Display(Name = "Creditering")]
    Credit = 1,

    [Display(Name = "Geen creditering")]
    CreditParent = 2
}