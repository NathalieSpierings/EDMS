using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Document.Rapportage.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Rapportage.Queries;

public class GetRapportageCreate : IQuery<RapportageCreateViewModel>
{
    public Guid OrganisatieId { get; set; }
    public Guid RapportageId { get; set; }
    public bool IncludeData { get; set; } = false;
}