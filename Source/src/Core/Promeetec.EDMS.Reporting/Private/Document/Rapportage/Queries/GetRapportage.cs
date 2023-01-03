using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Document.Rapportage.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Rapportage.Queries;

public class GetRapportage : IQuery<RapportageViewModel>
{
    public Guid RappoortageId { get; set; }
    public bool IncludeData { get; set; } = false;
}