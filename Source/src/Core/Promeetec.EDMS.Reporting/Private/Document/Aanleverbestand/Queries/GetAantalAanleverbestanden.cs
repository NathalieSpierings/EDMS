using System;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Queries;

public class GetAantalAanleverbestanden : IQuery<int>
{
    public Guid AanleveringId { get; set; }
    public UserPrincipal User { get; set; }
}