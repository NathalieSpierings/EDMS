using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Contact;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Contact;

public class QuickContactViewModel : ModelBase
{
    [Display(Name = "Uw naam")]
    [StringLength(256, ErrorMessage = "{0} moet minimaal {2} en maximaal {1} tekens bevatten.", MinimumLength = 2)]
    [RegularExpression(@"^(?:[u00C0-\u017Fa-zA-Z\-]+\s?)+[u00C0-\u017Fa-zA-Z\-]+$", ErrorMessage = "Alleen letters, spaties en koppeltekens zijn toegestaan.")]
    public string QuickContactName { get; set; }

    [Display(Name = "Telefoonnummer")]
    [DataType(DataType.PhoneNumber, ErrorMessage = "Dit is geen geldig telefoonnummer!")]
    [RegularExpression(@"(^\+[0-9]{2}|^\+[0-9]{2}\(0\)|^\(\+[0-9]{2}\)\(0\)|^00[0-9]{2}|^0)([0-9]{9}$|[0-9\-\s]{10}$)", ErrorMessage = "Dit is geen geldig telefoonnummer!")]
    [StringLength(13, ErrorMessage = "{0} moet minstens {2} cijfers bevatten en mag niet langer zijn dan {1} cijfers.", MinimumLength = 10)]
    public string QuickContactTelefoon { get; set; }

    [Display(Name = "E-mail")]
    [EmailAddress(ErrorMessage = "Dit is geen geldig e-mailadres!")]
    [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "Dit is geen geldig e-mailadres!")]
    [StringLength(200, ErrorMessage = "{0} moet minimaal {2} en maximaal {1} tekens bevatten.", MinimumLength = 6)]
    public string QuickContactEmail { get; set; }

    [Display(Name = "Bericht")]
    [UIHint("MultilineText"), Required(ErrorMessage = "Bericht is verplicht."), AllowHtml]
    public string QuickContactMessage { get; set; }

    public bool QuickContactTerugBellen { get; set; }

    [Display(Name = "Contact reden")]
    [Required(ErrorMessage = "Contact reden is verplicht.")]
    [Range(1, int.MaxValue, ErrorMessage = "Selecteer een contact reden.")]
    public QuickContactType QuickContactType { get; set; }

    public string OrganisatieDisplayName { get; set; }
    public string UserName { get; set; }

}