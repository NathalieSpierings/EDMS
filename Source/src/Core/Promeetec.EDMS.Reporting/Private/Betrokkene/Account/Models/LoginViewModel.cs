using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Account.Models;

public class LoginViewModel : ModelBase
{
    [Required(ErrorMessage = "Gebruikersnaam is verplicht.")]
    [Display(Name = "Gebruikersnaam")]
    [StringLength(256, ErrorMessage = "{0} moet minimaal {2} en maximaal {1} tekens bevatten.", MinimumLength = 6)]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Wachtwoord is verplicht.")]
    [DataType(DataType.Password)]
    [Display(Name = "Wachtwoord")]
    [MinLength(6, ErrorMessage = "Het wachtwoord moet minimaal {0} tekens bevatten")]
    public string Password { get; set; }


    [Display(Name = "Mij onthouden?")]
    [DefaultValue(false)]
    public bool RememberMe { get; set; }
}