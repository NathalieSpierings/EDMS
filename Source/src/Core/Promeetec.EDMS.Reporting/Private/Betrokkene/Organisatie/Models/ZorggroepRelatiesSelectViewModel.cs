using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;

public class ZorggroepRelatiesSelectViewModel : ModelBase
{
    [Display(Name = "Zorggroep")]
    [Required(ErrorMessage = "Zorggroep is verplicht.")]
    public Guid ZorggroepId { get; set; }

    public SelectList Zorggroepen { get; set; }
}