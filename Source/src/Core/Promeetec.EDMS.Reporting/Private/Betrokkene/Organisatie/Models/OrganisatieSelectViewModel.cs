using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;

public class OrganisatieSelectViewModel : ModelBase
{
    [Display(Name = "Organisatie")]
    [Required(ErrorMessage = "Organisatie is verplicht.")]
    public Guid OrganisatieId { get; set; }

    public SelectList Organisaties { get; set; }
}