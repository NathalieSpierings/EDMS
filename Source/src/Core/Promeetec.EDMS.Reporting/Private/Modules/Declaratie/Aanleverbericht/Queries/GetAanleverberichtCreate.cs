using System;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanleverbericht.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanleverbericht.Queries;

public class GetAanleverberichtCreate : IQuery<AanleverberichtCreateViewModel>
{
    public Guid AanleveringId { get; set; }
    public Guid OrganisatieId { get; set; }
    public UserPrincipal User { get; set; }
}