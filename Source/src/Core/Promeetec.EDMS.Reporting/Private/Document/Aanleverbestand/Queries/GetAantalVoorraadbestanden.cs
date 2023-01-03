using System;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Queries;

public class GetAantalVoorraadbestanden : IQuery<int>
{
    public Guid VoorraadId { get; set; }
    public Guid OrganisatieId { get; set; }
    public UserPrincipal User { get; set; }
}