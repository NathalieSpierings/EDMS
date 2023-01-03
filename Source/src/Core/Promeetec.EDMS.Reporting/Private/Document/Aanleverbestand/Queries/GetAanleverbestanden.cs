using System;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Queries;

public class GetAanleverbestanden : IQuery<AanleverbestandenViewModel>
{
    public Guid? VoorraadId { get; set; }
    public Guid? AanleveringId { get; set; }
    public UserPrincipal User { get; set; }
}