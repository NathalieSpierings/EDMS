using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Verbruiksmiddel.Models;

public class VerbruiksmiddelPrestatieCreateViewModel : ModelBase
{
    public Guid Id { get; set; }
    public Guid OrganisatieId { get; set; }

    [Remote("IsAgbValid", "Verbruiksmiddel", ErrorMessage = "AGB-code onderneming/vestiging bestaat uit 8 cijfers!.", HttpMethod = "POST")]
    [Required(ErrorMessage = "AGB-code onderneming/vestiging verplicht.")]
    [Display(Name = "AGB-code onderneming/vestiging")]
    public string AgbCodeOnderneming { get; set; }


    [Display(Name = "Soort")]
    public HulpmiddelenSoort HulpmiddelenSoort { get; set; }

    public VerbruiksmiddelPrestatieStatus Status { get; set; }


    [Display(Name = "Cliënt")]
    [Required(ErrorMessage = "Cliënt is verplicht.")]
    public Guid VerzekerdeId { get; set; }

    [Display(Name = "Cliënt")]
    public SelectList Verzekerden { get; set; }

    public VerzekerdeViewModel Verzekerde { get; set; }

    public VerbruiksmiddelHulpmiddelCreateViewModel Hulpmiddel { get; set; }
}