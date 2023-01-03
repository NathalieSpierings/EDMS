using System.Web.Mvc;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Models;

public class VerzekerdeSelectList : ModelBase
{
    public SelectList Verzekerden { get; set; }
}