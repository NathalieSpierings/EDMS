using Promeetec.EDMS.Domain.Models.Document.Bestand;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Private.Document.Bestand.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.DownloadActivity.Models;

public class DownloadActivityModel : ModelBase
{
    public DateTime GedownloadOp { get; set; }
    public BestandSoort BestandSoort { get; set; }
    public BestandViewModel Bestand { get; set; }
    public MedewerkerViewModel Medewerker { get; set; }

}