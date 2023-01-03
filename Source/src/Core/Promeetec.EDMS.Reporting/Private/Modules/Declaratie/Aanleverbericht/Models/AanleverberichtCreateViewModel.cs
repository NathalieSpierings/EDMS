using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanleverbericht.Models;

public class AanleverberichtCreateViewModel
{
    // Organisatie details
    public Guid OrganisatieId { get; set; }
    public string OrganisatieDisplayName { get; set; }


    // Aanlevering details
    public Guid AanleveringId { get; set; }
    public string Referentie { get; set; }
    public MedewerkerViewModel Ontvanger { get; set; }
    public MedewerkerViewModel Afzender { get; set; }


    [Display(Name = "Onderwerp")]
    [Required(ErrorMessage = "Ondewerp is verplicht.")]
    [StringLength(256, ErrorMessage = "{0} moet minimaal {2} en maximaal {1} tekens bevatten.", MinimumLength = 1)]
    public string Onderwerp { get; set; }

    [AllowHtml]
    [UIHint("MultilineText"), Required(ErrorMessage = "Bericht is verplicht.")]
    [Display(Name = "Bericht")]
    public string Bericht { get; set; }
}