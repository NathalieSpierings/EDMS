using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Admin.RedenEindeZorg.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.RedenEindeZorg.Queries;

public class GetRedenEindeZorg : IQuery<RedenEindeZorgViewModel>
{
    public Guid RedenEindeZorgId { get; set; }
}