using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Account.Models;

public class ExternalLoginConfirmationViewModel
{
    [Required]
    [Display(Name = "Email")]
    public string Email { get; set; }
}