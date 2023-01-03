using System;
using Promeetec.EDMS.Reporting.Private.Document.Bestand.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Overigbestand.Models;

public class OverigbestandViewModel : BestandCreateViewModel
{
    public Guid AanleveringId { get; set; }
    public FilesViewModel Files { get; set; }
}