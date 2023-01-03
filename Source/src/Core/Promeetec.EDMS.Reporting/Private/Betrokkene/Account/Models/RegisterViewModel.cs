using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Betrokkene.Persoon;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Account.Models;

public class RegisterViewModel
{
    public Geslacht Geslacht { get; set; }
    public string Voorletters { get; set; }
    public string Tussenvoegsel { get; set; }
    public string Voornaam { get; set; }
    public string Achternaam { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

}