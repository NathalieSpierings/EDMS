using System.Web.Mvc;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;

public class MedewerkerSoortSelectList : ModelBase
{
    public SelectList MedewerkerSoorten { get; set; }
}