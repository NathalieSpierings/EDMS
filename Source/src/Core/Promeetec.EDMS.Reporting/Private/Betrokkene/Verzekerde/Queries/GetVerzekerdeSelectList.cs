using System;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Queries;

public class GetVerzekerdeSelectList : IQuery<VerzekerdeSelectList>
{
    public UserPrincipal User { get; set; }
    public Guid OrganisatieId { get; set; }
    public bool IsGliVerzekerde { get; set; } = false;
}