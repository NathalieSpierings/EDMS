using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Notificatie.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Notificatie.Queries;

public class GetNotificaties : IQuery<NotificatiesViewModel>
{
    public Guid MedewerkerId { get; set; }
    public Guid OrganisatieId { get; set; }
    public string SearchTerm { get; set; }
    public bool All { get; set; }
}