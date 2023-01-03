using System;
using Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Models;

public class AanleveringAanleverbestandenViewModel : ModelBase
{
    public Guid Id { get; set; }
    public AanleverbestandenViewModel Aanleverbestanden { get; set; }
}