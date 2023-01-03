using System;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Betrokkene.Persoon;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Persoon.Models;

public class PersoonCreateEditViewModel : ModelBase
{
    [Required(ErrorMessage = "Geslacht is verplicht.")]
    [Range(1, int.MaxValue, ErrorMessage = "Selecteer een geslacht.")]
    public Geslacht Geslacht { get; set; }

    [UIHint("Date")]
    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [RegularExpression(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$", ErrorMessage = "Dit is geen geldige datum!")]
    public DateTime? Geboortedatum { get; set; }


    [Display(Name = "Voorletters")]
    [Required(ErrorMessage = "Voorletters is verplicht.")]
    [StringLength(20, ErrorMessage = "{0} kan maximaal {1} tekens bevatten.")]
    public string Voorletters { get; set; }

    [Display(Name = "Tussenvoegsel")]
    [StringLength(20, ErrorMessage = "{0} kan maximaal {1} tekens bevatten.")]
    public string Tussenvoegsel { get; set; }

    [Display(Name = "Voornaam")]
    [RegularExpression(@"^(?:[u00C0-\u017Fa-zA-Z\-]+\s?)+[u00C0-\u017Fa-zA-Z\-]+$", ErrorMessage = "Alleen letters, spaties en koppeltekens zijn toegestaan.")]
    [StringLength(200, ErrorMessage = "{0} kan maximaal {1} tekens bevatten.")]
    public string Voornaam { get; set; }


    [Display(Name = "Achternaam")]
    [Required(ErrorMessage = "Achternaam is verplicht.")]
    [RegularExpression(@"^(?:[u00C0-\u017Fa-zA-Z\-]+\s?)+[u00C0-\u017Fa-zA-Z\-]+$", ErrorMessage = "Alleen letters, spaties en koppeltekens zijn toegestaan.")]
    [StringLength(256, ErrorMessage = "{0} kan maximaal {1} tekens bevatten.")]
    public string Achternaam { get; set; }


    [Display(Name = "Naam")]
    public string FormeleNaam { get; set; }


    [Display(Name = "Naam")]
    public string VolledigeNaam { get; set; }


    [Display(Name = "Telefoonnummer zakelijk")]
    [RegularExpression(@"^[^\s].+[^\s]$", ErrorMessage = "Dit is geen geldig telefoonnummer!")]
    [DataType(DataType.PhoneNumber, ErrorMessage = "Dit is geen geldig telefoonnummer!")]
    [StringLength(15, ErrorMessage = "{0} moet minstens {2} cijfers bevatten en mag niet langer zijn dan {1} cijfers.", MinimumLength = 10)]
    public string Telefoon { get; set; }

    [Display(Name = "Telefoonnummer privé")]
    [RegularExpression(@"^[^\s].+[^\s]$", ErrorMessage = "Dit is geen geldig telefoonnummer!")]
    [DataType(DataType.PhoneNumber, ErrorMessage = "Dit is geen geldig telefoonnummer!")]
    [StringLength(15, ErrorMessage = "{0} moet minstens {2} cijfers bevatten en mag niet langer zijn dan {1} cijfers.", MinimumLength = 10)]
    public string Telefoon1 { get; set; }


    [StringLength(50, ErrorMessage = "{0} kan maximaal {1} tekens bevatten.")]
    public string Doorkiesnummer { get; set; }


    [Display(Name = "E-mail")]
    [EmailAddress(ErrorMessage = "Dit is geen geldig e-mailadres!")]
    [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "Dit is geen geldig e-mailadres!")]
    [StringLength(450, ErrorMessage = "{0} moet minimaal {2} en maximaal {1} tekens bevatten.", MinimumLength = 6)]
    public string Email { get; set; }
}