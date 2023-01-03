using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekeraar.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekeraar.Queries;

public class GetVerzekeraar : IQuery<VerzekeraarViewModel>
{
    public Guid VerzekeraarId { get; set; }
}