using System;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Adres.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Persoon.Models;
using Promeetec.EDMS.Reporting.Private.Identity.Group.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;

public class MedewerkerCreateViewModel : PersoonCreateEditViewModel
{
    public Guid OrganisatieId { get; set; }
    public string OrganisatieNaam { get; set; }
    public MedewerkerSoort MedewerkerSoort { get; set; }

    [Display(Name = "AGB-code zorgverlener")]
    public string AgbCodeZorgverlener { get; set; }

    [Required(ErrorMessage = "AGB-code onderneming is verplicht.")]
    [Display(Name = "AGB-code onderneming")]
    public string AgbCodeOnderneming { get; set; }


    [StringLength(200, ErrorMessage = "{0} kan maximaal {1} tekens bevatten.")]
    public string Functie { get; set; }


    [Display(Name = "ION toestemmingsverklaring activatie link")]
    public string IONToestemmingsverklaringActivatieLink { get; set; }

    public AdresViewModel Adres { get; set; }
    public GroupSelectList GroupSelect { get; set; }
}