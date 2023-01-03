using System;
using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Account.Models;

public class GoogleAuthenticatorViewModel
{
    public Guid UserId { get; set; }

    [Required]
    [Display(Name = "verificatiecode")]
    public string VerificatieCode { get; set; }

    public string SecretKey { get; set; }

    public string BarcodeUrl { get; set; }
}