using System;
using Promeetec.EDMS.Domain.Models.Document.Rapportage;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Rapportage.Models;

public class RapportageViewModel : ModelBase
{
    public Guid Id { get; set; }
    public string Referentie { get; set; }
    public RapportageSoort RapportageSoort { get; set; }
    public string FileName { get; set; }
    public int FileSize { get; set; }
    public string Extension { get; set; }
    public DateTime AangemaaktOp { get; set; }
    public Guid EigenaarId { get; set; }
    public string EigenaarNaam { get; set; }
    public Guid OrganisatieId { get; set; }
    public string OrganisatieNaam { get; set; }
    public string MimeType { get; set; }
    public byte[] Data { get; set; }
}