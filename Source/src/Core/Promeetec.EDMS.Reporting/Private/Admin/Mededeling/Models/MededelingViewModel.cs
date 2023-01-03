using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.Mededeling.Models;

public class MededelingViewModel : ModelBase
{
    [AllowHtml]
    [DataType(DataType.MultilineText)]
    public string Content { get; set; }
}