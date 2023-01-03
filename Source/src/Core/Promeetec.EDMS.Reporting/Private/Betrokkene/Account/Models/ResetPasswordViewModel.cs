using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Account.Models;

public class ResetPasswordViewModel
{
    [Display(Name = "Gebruikersnaam")]
    [Required(ErrorMessage = "Gebruikersnaam is verplicht.")]
    [StringLength(256, ErrorMessage = "{0} moet minimaal {2} en maximaal {1} tekens bevatten.", MinimumLength = 6)]
    public string UserName { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "{0} moet minimaal {2} en maximaal {1} tekens bevatten.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Wachtwoord")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Herhaal wachtwoord")]
    [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Het wachtwoord en herhaal wachtwoord zijn ongelijk.")]
    public string ConfirmPassword { get; set; }

    [Remote("PukCodeCheck", "Account", AdditionalFields = "UserName", ErrorMessage = "De PUK-code is onjuist.", HttpMethod = "POST")]
    [Display(Name = "PUK-code")]
    [Required(ErrorMessage = "PUK-code is verplicht.")]
    public string PukCode { get; set; }

    public string Code { get; set; }
}