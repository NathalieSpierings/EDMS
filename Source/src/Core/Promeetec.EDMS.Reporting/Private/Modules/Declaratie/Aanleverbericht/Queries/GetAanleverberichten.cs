using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanleverbericht.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanleverbericht.Queries;

public class GetAanleverberichten : IQuery<AanleverberichtenViewModel>
{
    public Guid? AanleveringId { get; set; }
    public Guid? BehandelaarId { get; set; }
    public string SearchTerm { get; set; }
}