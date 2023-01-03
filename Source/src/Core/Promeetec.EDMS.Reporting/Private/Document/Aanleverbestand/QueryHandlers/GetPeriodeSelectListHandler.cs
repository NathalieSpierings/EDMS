using System.Linq;
using System.Web.Mvc;
using Promeetec.EDMS.Extensions;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Models;
using Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Queries;

namespace Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.QueryHandlers;

public class GetPeriodeSelectListHandler : IQueryHandler<GetPeriodeSelectList, PeriodeSelectList>
{
    public GetPeriodeSelectListHandler()
    {
    }

    public PeriodeSelectList Handle(GetPeriodeSelectList query)
    {
        var periodes = query.Datum.GetPeriods(query.AantalTeTonenKwartalen).ToList();

        return new PeriodeSelectList
        {
            Periodes = new SelectList(periodes, "Key", "Value")
        };
    }
}