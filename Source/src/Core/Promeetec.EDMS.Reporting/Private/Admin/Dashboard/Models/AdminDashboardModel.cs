using Promeetec.EDMS.Reporting.Private.Admin.Mededeling.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.Dashboard.Models;

public class AdminDashboardModel : ModelBase
{
    public int AantalActieveOrganisaties { get; set; }
    public int AantalBeperkteOrganisaties { get; set; }
    public int AantalActieveMedewerkers { get; set; }
    public int AantalOnlineUsers { get; set; }
    public MededelingViewModel Mededeling { get; set; }
}