using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Models;

public class MachtigingActiviteitSelectViewModel : ModelBase
{
    [Display(Name = "Zorgactiviteit")]
    [Required(ErrorMessage = "Zorgactiviteit is verplicht.")]
    public Guid ActiviteitId { get; set; }

    public SelectList Activiteiten { get; set; }
}