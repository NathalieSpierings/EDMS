using System;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.WeegMoment.Models;

public class WeegMomentCreateViewModel : ModelBase
{
    public Guid Id { get; set; }
    public Guid VerzekerdeId { get; set; }
    public double? VerzekerdeLengte { get; set; }
    public double? Lengte { get; set; }
    public double? Gewicht { get; set; }

    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [Display(Name = "Gewicht opnamedatum")]
    public DateTime? Opnamedatum { get; set; }
    public string CssClass { get; set; }

}