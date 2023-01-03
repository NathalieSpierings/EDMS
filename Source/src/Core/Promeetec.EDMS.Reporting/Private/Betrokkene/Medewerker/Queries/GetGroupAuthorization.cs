using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Queries;

public class GetGroupAuthorization : IQuery<GroupAuthorizationViewModel>
{
    public Guid MedewerkerId { get; set; }
}