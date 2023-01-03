using System;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Notificatie.Models;

public class NotificatieViewModel : ModelBase
{
    public Guid Id { get; set; }
    public bool Read { get; set; }
    public bool Delete { get; set; }
}