using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Models.Contact;

public enum ContactType
{
    [Display(Name = "Ik heb een vraag")]
    Vraag = 1,

    [Display(Name = "Ik heb een suggestie")]
    Suggestie = 2,

    [Display(Name = "Ik heb een klacht")]
    Klacht = 3,

    Anders = 4
}
