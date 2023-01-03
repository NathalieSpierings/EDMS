using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Rapportage.Models;

public class RapportagesViewModel : ModelBase
{
    [HiddenInput(DisplayValue = false)]
    public string HiddenFileIds { get; set; }

    public string SearchTerm { get; set; }
    public bool All { get; set; }
    public Guid OrganisatieId { get; set; }
    public string OrganisatieNaam { get; set; }
    public IEnumerable<RapportageListItemViewModel> Rapportages { get; set; } = new List<RapportageListItemViewModel>();
}