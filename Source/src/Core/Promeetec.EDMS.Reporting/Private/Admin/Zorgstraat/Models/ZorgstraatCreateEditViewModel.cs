using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.Zorgstraat.Models;

public class ZorgstraatCreateEditViewModel : ModelBase
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Naam is verplicht.")]
    [StringLength(256, ErrorMessage = "De {0} moet minstens {2} tekens bevatten.", MinimumLength = 2)]
    public string Naam { get; set; }

    [Display(Name = "Status")]
    [Required(ErrorMessage = "Status is verplicht.")]
    public Status Status { get; set; }
    public SelectList Statussen { get; set; }
}