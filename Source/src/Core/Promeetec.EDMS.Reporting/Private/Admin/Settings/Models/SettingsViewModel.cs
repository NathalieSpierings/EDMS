using System;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.Settings.Models;

public class SettingsViewModel : ModelBase
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Straat is verplicht!")]
    [StringLength(200, ErrorMessage = "{0} kan maximaal {1} tekens bevatten.")]
    public string Straat { get; set; }


    [Required(ErrorMessage = "Huisnummer is verplicht!")]
    [StringLength(50, ErrorMessage = "{0} kan maximaal {1} tekens bevatten.")]
    public string Huisnummer { get; set; }

    [Display(Name = "Huisnr. toevoeging")]
    [StringLength(50, ErrorMessage = "{0} kan maximaal {1} tekens bevatten.")]
    public string HuisnummerToevoeging { get; set; }


    [Required(ErrorMessage = "Postcode is verplicht!")]
    [StringLength(50, ErrorMessage = "{0} kan maximaal {1} tekens bevatten.")]
    public string Postcode { get; set; }

    [Required(ErrorMessage = "Woonplaats is verplicht!")]
    [StringLength(200, ErrorMessage = "{0} kan maximaal {1} tekens bevatten.")]
    public string Woonplaats { get; set; }

    [Required(ErrorMessage = "Telefoonnummer is verplicht!")]
    [Display(Name = "Telefoonnummer")]
    [RegularExpression(@"^[^\s].+[^\s]$", ErrorMessage = "Dit is geen geldig telefoonnummer!")]
    [DataType(DataType.PhoneNumber, ErrorMessage = "Dit is geen geldig telefoonnummer!")]
    [StringLength(15, ErrorMessage = "{0} moet minstens {2} cijfers bevatten en mag niet langer zijn dan {1} cijfers.", MinimumLength = 10)]
    public string Telefoon { get; set; }

    [Required(ErrorMessage = "E-mailadres is verplicht!")]
    [Display(Name = "E-mailadres")]
    [EmailAddress(ErrorMessage = "Dit is geen geldig e-mailadres!")]
    [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "Dit is geen geldig e-mailadres!")]
    [StringLength(450, ErrorMessage = "{0} moet minimaal {2} en maximaal {1} tekens bevatten.", MinimumLength = 6)]
    public string Email { get; set; }

    public SettingsHaarwerkViewModel Haarwerk { get; set; } = new();
}


public class SettingsHaarwerkViewModel : ModelBase
{
    [Required(ErrorMessage = "Bedrag basis verzekering is verplicht!")]
    [Display(Name = "Basis verzekering")]
    public decimal BedragBasisVerzekering { get; set; }

}
