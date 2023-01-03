using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Queries;

public class GetVerzekerdeCreate : IQuery<VerzekerdeCreateViewModel>
{
    public Guid VerzekerdeId { get; set; }
}