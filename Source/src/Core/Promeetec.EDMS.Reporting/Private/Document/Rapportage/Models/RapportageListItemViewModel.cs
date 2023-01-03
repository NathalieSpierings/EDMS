using System;
using Promeetec.EDMS.Domain.Models.Document.Rapportage;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Rapportage.Models;

public class RapportageListItemViewModel : ModelBase
{
    public Guid Id { get; set; }
    public string Referentie { get; set; }
    public RapportageSoort RapportageSoort { get; set; }
    public string FileName { get; set; }
    public int FileSize { get; set; }
    public string Extension { get; set; }
    public DateTime AangemaaktOp { get; set; }
    public Guid EigenaarId { get; set; }
    public string EigenaarFormeleNaam { get; set; }
    public Guid BehandelaarId { get; set; }
    public string BehandelaarNaam { get; set; }
    public Guid OrganisatieId { get; set; }
    public string OrganisatieNaam { get; set; }
    public bool Exported { get; set; }
    public DateTime ExportedOn { get; set; }

}