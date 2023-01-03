using System;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Document.Overigbestand.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Overigbestand.Queries;

public class GetOverigbestand : IQuery<OverigbestandViewModel>
{
    public Guid OrganisatieId { get; set; }
    public Guid OverigbestandId { get; set; }
    public UserPrincipal User { get; set; }
}