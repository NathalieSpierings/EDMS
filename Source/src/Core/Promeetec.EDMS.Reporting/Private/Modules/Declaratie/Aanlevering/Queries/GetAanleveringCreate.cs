using System;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Queries;

public class GetAanleveringCreate : IQuery<AanleveringCreateViewModel>
{
    public Guid AanleveringId { get; set; }
    public Guid? OrganisatieId { get; set; }
    public UserPrincipal User { get; set; }
    public bool IncludeAanleverbestanden { get; set; } = false;
    public bool IncludeOverigebestanden { get; set; } = false;
}