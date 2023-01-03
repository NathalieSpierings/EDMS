using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Betrokkene.Persoon;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Persoon.Models;

public class PersoonModel : ModelBase
{
    public Geslacht Geslacht { get; set; }

    [DataType(DataType.Date)]
    public DateTime? Geboortedatum { get; set; }

    public string Voorletters { get; set; }
    public string Voornaam { get; set; }
    public string Tussenvoegsel { get; set; }
    public string Achternaam { get; set; }


    [Display(Name = "Naam")]
    public string FormeleNaam { get; set; }


    [Display(Name = "Naam")]
    public string VolledigeNaam { get; set; }


    [Display(Name = "Telefoonnummer zakelijk")]
    [DataType(DataType.PhoneNumber)]
    public string Telefoon { get; set; }

    [Display(Name = "Telefoonnummer privé")]
    [DataType(DataType.PhoneNumber)]
    public string Telefoon1 { get; set; }

    public string Doorkiesnummer { get; set; }

    [Display(Name = "E-mail")]
    public string Email { get; set; }
}