using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.Monitor.Models;

public class SessiesViewModel : ModelBase
{
    public List<SessionInformation> Sessions => ApplicationState.GetSessions();
}