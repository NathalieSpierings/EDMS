using System;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Queries;

public class GetAanleverbestandCreate : IQuery<AanleverbestandCreateViewModel>
{
    public Guid OrganisatieId { get; set; }
    public Guid AanleverbestandId { get; set; }
    public bool IncludeData { get; set; } = false;
    public UserPrincipal User { get; set; }
}