using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Queries;

public class GetVerzekerdeEdit : IQuery<VerzekerdeEditViewModel>
{
    public Guid OrganisatieId { get; set; }
    public Guid VerzekerdeId { get; set; }
}