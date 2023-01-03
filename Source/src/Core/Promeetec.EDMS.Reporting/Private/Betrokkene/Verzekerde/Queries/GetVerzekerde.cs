using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Queries;

public class GetVerzekerde : IQuery<VerzekerdeViewModel>
{
    public Guid VerzekerdeId { get; set; }
}