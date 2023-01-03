using System;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Queries;

public class GetAanleveringen : IQuery<AanleveringenViewModel>
{
    public Guid? OrganisatieId { get; set; }
    public Guid? BehandelaarId { get; set; }

    public bool IncludeDeletes { get; set; } = false;
    public string SearchTerm { get; set; }
    public UserPrincipal User { get; set; }
}