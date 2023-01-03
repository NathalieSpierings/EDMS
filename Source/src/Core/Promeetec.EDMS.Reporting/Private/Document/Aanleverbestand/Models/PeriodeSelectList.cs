using System.Web.Mvc;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Models;

public class PeriodeSelectList : ModelBase
{
    public SelectList Periodes { get; set; }
}