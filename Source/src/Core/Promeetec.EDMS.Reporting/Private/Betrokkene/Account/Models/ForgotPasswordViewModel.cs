using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Account.Models;

public class ForgotPasswordViewModel : ModelBase
{
    [Display(Name = "Gebruikersnaam")]
    [Required(ErrorMessage = "Gebruikersnaam is verplicht.")]
    [StringLength(256, ErrorMessage = "{0} moet minimaal {2} en maximaal {1} tekens bevatten.", MinimumLength = 6)]
    public string UserName { get; set; }
}