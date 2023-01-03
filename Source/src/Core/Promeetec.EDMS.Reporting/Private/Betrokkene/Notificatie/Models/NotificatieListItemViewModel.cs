using System;
using Promeetec.EDMS.Domain.Models.Betrokkene.Notificatie;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Notificatie.Models;

public class NotificatieListItemViewModel : ModelBase
{
    public Guid Id { get; set; }
    public string Titel { get; set; }
    public string Bericht { get; set; }
    public NotificatieType NotificatieType { get; set; }
    public string Url { get; set; }
    public NotificatieStatus NotificatieStatus { get; set; }
    public DateTime Datum { get; set; }
    public Guid MedewerkerId { get; set; }
    public Guid OrganisatieId { get; set; }
}