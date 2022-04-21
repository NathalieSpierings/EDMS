using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Models.Contact;

public enum QuickContactType
{
    [Display(Name = "Ik heb een vraag over een aanlevering")]
    VraagAanlevering = 1,

    [Display(Name = "Ik heb een vraag over een rapportage")]
    VraagRapportage = 2,

    [Display(Name = "Ik heb een vraag over GLI")]
    VraagGli = 3,

    [Display(Name = "Ik heb een vraag over verbruiksmiddelen")]
    VraagVerbruiksmiddelen = 4,

    [Display(Name = "Ik heb een vraag over ION")]
    VraagION = 5,

    Anders = 6
}
