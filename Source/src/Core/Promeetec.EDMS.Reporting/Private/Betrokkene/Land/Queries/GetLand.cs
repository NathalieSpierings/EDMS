using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Land.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Land.Queries;

public class GetLand : IQuery<LandViewModel>
{
    public Guid LandId { get; set; }
    public string LandCode { get; set; }
}