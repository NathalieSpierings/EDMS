using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Betrokkene.Persoon;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.QueryHandlers;

public class GetVerzekerdeSelectListHandler : IQueryHandlerAsync<GetVerzekerdeSelectList, VerzekerdeSelectList>
{
    private readonly IVerzekerdeRepository _repository;

    public GetVerzekerdeSelectListHandler(IVerzekerdeRepository repository)
    {
        _repository = repository;
    }

    public async Task<VerzekerdeSelectList> HandleAsync(GetVerzekerdeSelectList query)
    {
        await Task.CompletedTask;
        var dbQuery = _repository.Query()
            .AsNoTracking()
            .Where(x => x.Adresboek.Organisatie.Id == query.OrganisatieId && x.Status == Status.Actief);

        if (query.IsGliVerzekerde)
        {
            dbQuery = dbQuery
                .Include(i => i.GliIntakes)
                .Where(x => x.GliIntakes.Count == 0);
        }

        List<SelectListItem> result = new List<SelectListItem>();

        // Interne user & Adresboek Level 2 gebruikers zien alle clienten uit het adresboek
        if (query.User.IsInterneMedewerker || query.User.IsInRole(RoleNames.ToevoegenClient))
        {
            foreach (var item in dbQuery.OrderBy(o => o.Persoon.Achternaam))
            {
                var geslacht = item.Persoon.Geslacht == Geslacht.Vrouwelijk ? "Mevr. "
                    : item.Persoon.Geslacht == Geslacht.Mannelijk ? "Dhr. "
                    : string.Empty;

                var datum = item.Persoon.Geboortedatum.HasValue ? item.Persoon.Geboortedatum.Value.ToString("dd-MM-yyyy") : string.Empty;

                result.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = string.Concat(geslacht, item.Persoon.FormeleNaam, "  [", datum, "]")
                });
            }
        }
        else
        {
            dbQuery = dbQuery.Where(x => x.Users.Any(i => i.UserId == query.User.Id)).OrderBy(o => o.Persoon.Achternaam);
            foreach (var item in dbQuery)
            {
                var geslacht = item.Persoon.Geslacht == Geslacht.Vrouwelijk ? "Mevr. "
                    : item.Persoon.Geslacht == Geslacht.Mannelijk ? "Dhr. "
                    : string.Empty;

                var datum = item.Persoon.Geboortedatum.HasValue ? item.Persoon.Geboortedatum.Value.ToString("dd-MM-yyyy") : string.Empty;

                result.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = string.Concat(geslacht, item.Persoon.FormeleNaam, "  [", datum, "]")
                });
            }
        }

        return new VerzekerdeSelectList
        {
            Verzekerden = new SelectList(result, "Value", "Text")
        };
    }
}