using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Queries;

public class GetVoorraadbestandenForExport : IQuery<VoorraadbestandenExportViewModel>
{
    public Guid VoorraadId { get; set; }
}