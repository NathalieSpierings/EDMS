using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Admin.Eistandaard.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.Eistandaard.Queries;

public class GetEiStandaard : IQuery<EiStandaardViewModel>
{
    public Guid EiStandaardId { get; set; }
}