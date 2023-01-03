using System.Web.Mvc;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Land.Models;

public class LandSelectList : ModelBase
{
    public SelectList Landen { get; set; }
}