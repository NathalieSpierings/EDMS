using System;
using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Notificatie.Queries;

public class GetNotificatieCount : IQuery<int>
{
    public Guid MedewerkerId { get; set; }
    public Guid OrganisatieId { get; set; }
}