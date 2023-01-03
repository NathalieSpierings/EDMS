using System.Collections.Generic;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.Prullenbak.Models;

public class PrullenbakViewModel : ModelBase
{
    public List<PrullenbakListItemViewModel> PrullenbakItems { get; set; } = new();
}