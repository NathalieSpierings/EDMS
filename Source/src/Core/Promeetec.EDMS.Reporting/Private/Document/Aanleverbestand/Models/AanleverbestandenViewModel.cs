using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Models;

public class AanleverbestandenViewModel : ModelBase
{
    [HiddenInput(DisplayValue = false)]
    public string HiddenFileIds { get; set; }
    public Guid AanleveringId { get; set; }

    public IEnumerable<AanleverbestandListItemViewModel> Aanleverbestanden { get; set; } = new List<AanleverbestandListItemViewModel>();
}