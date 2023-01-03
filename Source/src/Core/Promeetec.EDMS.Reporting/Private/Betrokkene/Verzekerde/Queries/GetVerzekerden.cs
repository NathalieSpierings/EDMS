using System;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Queries;

public class GetVerzekerden : IQuery<VerzekerdenViewModel>
{
    public Guid AdresboekId { get; set; }
    public Guid OrganisatieId { get; set; }
    public UserPrincipal User { get; set; }
}