using System;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.ION.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.ION.Queries;

public class GetAangeleverdeIONPopulaties : IQuery<AangeleverdeIONPopulatiesViewModel>
{
    public Guid OrganisatieId { get; set; }
    public bool Zorggroep { get; set; }
    public string SearchTerm { get; set; }
    public UserPrincipal User { get; set; }
}