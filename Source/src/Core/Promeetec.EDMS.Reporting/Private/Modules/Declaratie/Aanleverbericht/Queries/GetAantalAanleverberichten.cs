using System;
using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanleverbericht.Queries;

public class GetAantalAanleverberichten : IQuery<int>
{
    public Guid? AanleveringId { get; set; }
}