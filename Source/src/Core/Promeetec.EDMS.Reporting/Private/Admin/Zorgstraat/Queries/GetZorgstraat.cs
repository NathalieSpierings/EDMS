using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Admin.Zorgstraat.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.Zorgstraat.Queries;

public class GetZorgstraat : IQuery<ZorgstraatViewModel>
{
    public Guid ZorgstraatId { get; set; }
}