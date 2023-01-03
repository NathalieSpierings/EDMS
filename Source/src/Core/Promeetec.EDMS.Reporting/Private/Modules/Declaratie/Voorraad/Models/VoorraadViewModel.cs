using System;
using Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Voorraad.Models;

public class VoorraadViewModel : ModelBase
{
    public Guid Id { get; set; }
    public AanleverbestandenViewModel Voorraadbestanden { get; set; }
}