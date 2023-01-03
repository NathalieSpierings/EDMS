using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanleverbericht.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanleverbericht.Queries;

public class GetAanleverbericht : IQuery<AanleverberichtViewModel>
{
    public Guid AanleverberichtId { get; set; }
    public Guid AanleveringId { get; set; }
}