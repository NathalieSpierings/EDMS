using System;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.GLI.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.GLI.Queries;

public class GetGliRegistraties : IQuery<GliRegistratiesViewModel>
{
    public Guid OrganisatieId { get; set; }
    public string SearchTerm { get; set; }
    public UserPrincipal User { get; set; }
}