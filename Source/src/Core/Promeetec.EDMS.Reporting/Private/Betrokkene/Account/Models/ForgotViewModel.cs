using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Account.Models;

public class ForgotViewModel
{
    [Required]
    [Display(Name = "Email")]
    public string Email { get; set; }
}