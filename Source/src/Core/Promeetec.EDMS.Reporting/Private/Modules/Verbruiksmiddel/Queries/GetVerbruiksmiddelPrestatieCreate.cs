using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Verbruiksmiddel.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Verbruiksmiddel.Queries;

public class GetVerbruiksmiddelPrestatieCreate : IQuery<VerbruiksmiddelPrestatieCreateViewModel>
{
    public Guid OrganisatieId { get; set; }
    public Guid VerbruiksmiddelPrestatieId { get; set; }
}