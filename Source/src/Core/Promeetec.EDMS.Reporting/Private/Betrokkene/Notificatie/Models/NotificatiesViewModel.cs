using System.Collections.Generic;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Notificatie.Models;

public class NotificatiesViewModel : ModelBase
{
    public string SearchTerm { get; set; }
    public int AantalOngelezen { get; set; }
    public IList<NotificatieListItemViewModel> Notificaties { get; set; }
}