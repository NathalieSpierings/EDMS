using Promeetec.EDMS.Domain.Models.Document.Bestand;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.DownloadActivity.Models;

public class DownloadActivityListItemModel : ModelBase
{
    public DateTime GedownloadOp { get; set; }
    public string Bestandsnaam { get; set; }
    public BestandSoort BestandSoort { get; set; }
    public Guid? AanleveringId { get; set; }
    public Guid? VoorraadId { get; set; }
    public Guid OrganisatieId { get; set; }
    public Guid BestandId { get; set; }
    public Guid DownloaderId { get; set; }
    public string DownloaderFormeleNaam { get; set; }
}