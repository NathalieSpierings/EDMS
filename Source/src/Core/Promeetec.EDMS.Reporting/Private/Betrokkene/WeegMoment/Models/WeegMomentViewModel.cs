using System;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.WeegMoment.Models;

public class WeegMomentViewModel : ModelBase
{
    public Guid VerzekerdeId { get; set; }
    public double? Lengte { get; set; }
    public double? Gewicht { get; set; }

    [DataType(DataType.Date)]
    public DateTime Opnamedatum { get; set; }
    public string CssClass { get; set; }
}