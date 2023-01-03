using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.QueryHandlers;

public class GetMedewerkerSoortSelectListHandler : IQueryHandlerAsync<GetMedewerkerSoortSelectList, MedewerkerSoortSelectList>
{
    public async Task<MedewerkerSoortSelectList> HandleAsync(GetMedewerkerSoortSelectList query)
    {
        await Task.CompletedTask;

        var selectlist = Enum.GetValues(typeof(MedewerkerSoort)).Cast<MedewerkerSoort>().Where(x => x != MedewerkerSoort.Extern)
            .Select(x => new SelectListItem
            {
                Value = ((int)x).ToString(),
                Text = x.ToString(),
                Selected = query.MedewerkerSoort == x
            }).ToList();

        var model = new MedewerkerSoortSelectList
        {
            MedewerkerSoorten = new SelectList(selectlist, "Value", "Text")
        };

        return model;
    }
}