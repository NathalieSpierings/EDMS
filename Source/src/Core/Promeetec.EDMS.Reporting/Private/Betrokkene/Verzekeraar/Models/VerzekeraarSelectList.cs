using System.Web.Mvc;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekeraar.Models;

public class VerzekeraarSelectList : ModelBase
{
    public SelectList Verzekeraars { get; set; }
}