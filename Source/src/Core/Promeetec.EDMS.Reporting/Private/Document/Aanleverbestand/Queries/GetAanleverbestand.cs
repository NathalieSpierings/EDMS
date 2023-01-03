using System;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Queries;

public class GetAanleverbestand : IQuery<AanleverbestandViewModel>
{
    public Guid OrganisatieId { get; set; }
    public Guid AanleverbestandId { get; set; }
    public UserPrincipal User { get; set; }
}