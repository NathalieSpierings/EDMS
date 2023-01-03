using System;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Adresboek.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Adresboek.Queries;

public class GetAdresboekClienten : IQuery<AdresboekClientenViewModel>
{
    public Guid AdresboekId { get; set; }
    public Guid OrganisatieId { get; set; }
    public UserPrincipal User { get; set; }
}