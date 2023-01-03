using System;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Account.Models;

public class ChangePasswordViewModel : ModelBase
{
    public Guid UserId { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Huidig wachtwoord")]
    public string OldPassword { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "{0} moet minimaal {2} en maximaal {1} tekens bevatten.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Nieuw wachtwoord")]
    public string NewPassword { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Herhaal nieuw wachtwoord")]
    [Compare("NewPassword", ErrorMessage = "Het nieuwe wachtwoord en herhaal wachtwoord zijn ongelijk.")]
    public string ConfirmPassword { get; set; }
}