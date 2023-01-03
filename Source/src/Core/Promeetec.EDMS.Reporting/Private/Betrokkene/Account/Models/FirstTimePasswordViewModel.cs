using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Account.Models;

public class FirstTimePasswordViewModel : ModelBase
{
    public Guid UserId { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Uw tijdelijk wachtwoord")]
    [Required(ErrorMessage = "Het tijdelijk wachtwoord is verplicht.")]
    [Remote("TempPasswordCheck", "Account", AdditionalFields = "UserId", ErrorMessage = "Het tijdelijk wachtwoord is onjuist.", HttpMethod = "POST")]
    public string TempPassword { get; set; }


    [DataType(DataType.Password)]
    [Display(Name = "Wachtwoord")]
    [Required(ErrorMessage = "Wachtwoord is verplicht.")]
    public string Password { get; set; }


    [DataType(DataType.Password)]
    [Display(Name = "Herhaal wachtwoord")]
    [Required(ErrorMessage = "Herhaal wachtwoord is verplicht.")]
    [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "De wachtwoorden komen niet overeen.")]
    public string ConfirmPassword { get; set; }
}