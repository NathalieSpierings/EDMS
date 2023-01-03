using System.Web.Mvc;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.Zorgstraat.Models;

public class ZorgstratenSelectList : ModelBase
{
    public SelectList Zorgstraten { get; set; }
}