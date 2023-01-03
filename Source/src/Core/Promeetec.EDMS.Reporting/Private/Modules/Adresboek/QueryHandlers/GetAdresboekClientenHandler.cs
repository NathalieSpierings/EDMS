using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Domain.Models.Modules.Adresboek;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Modules.Adresboek.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Adresboek.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Adresboek.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.Adresboek.QueryHandlers;

public class GetAdresboekClientenHandler : IQueryHandlerAsync<GetAdresboekClienten, AdresboekClientenViewModel>
{
    private readonly IAdresboekRepository _adresboekRepository;

    public GetAdresboekClientenHandler(IAdresboekRepository adresboekRepository)
    {
        _adresboekRepository = adresboekRepository;
    }

    public async Task<AdresboekClientenViewModel> HandleAsync(GetAdresboekClienten query)
    {
        var model = new AdresboekClientenViewModel
        {
            OrganisatieId = query.OrganisatieId,
            AdresboekId = query.AdresboekId
        };

        var adresboek = await _adresboekRepository.Query()
            .AsNoTracking()
            .Include(i => i.Verzekerden)
            .Where(x => x.Id == query.AdresboekId && x.Organisatie.Id == query.OrganisatieId)
            .FirstOrDefaultAsync();


        // Interne user & Adresboek Level 2 gebruikers zien alle clienten uit het adresboek
        if (query.User.IsInterneMedewerker || query.User.IsInRole(RoleNames.ToevoegenClient))
        {
            model.Clienten = adresboek.Verzekerden
                .Where(y => y.Status != Status.Verwijderd)
                .OrderBy(o => o.Persoon.VolledigeNaam)
                .Select(x => new AdresboekClientListViewModel
                {
                    Id = x.Id,
                    OrganisatieId = x.Adresboek.Organisatie.Id,
                    AdresboekId = x.AdresboekId,
                    Status = x.Status,
                    Shared = x.Shared,
                    Geslacht = x.Persoon.Geslacht,
                    Geboortedatum = x.Persoon.Geboortedatum ?? DateTime.MinValue,
                    Achternaam = x.Persoon.Achternaam,
                    VolledigeNaam = x.Persoon.VolledigeNaam,
                    HasZorgprofiel = x.Zorgprofiel?.ProfielCode != null
                }).ToList();
        }
        else
        {
            model.Clienten = adresboek.Verzekerden
                .Where(x => x.Status != Status.Verwijderd && x.Users.Any(i => i.UserId == query.User.Id))
                .OrderBy(o => o.Persoon.VolledigeNaam)
                .Select(x => new AdresboekClientListViewModel
                {
                    Id = x.Id,
                    OrganisatieId = x.Adresboek.Organisatie.Id,
                    AdresboekId = x.AdresboekId,
                    Status = x.Status,
                    Shared = x.Shared,
                    Geslacht = x.Persoon.Geslacht,
                    Geboortedatum = x.Persoon.Geboortedatum ?? DateTime.MinValue,
                    Achternaam = x.Persoon.Achternaam,
                    VolledigeNaam = x.Persoon.VolledigeNaam,
                    HasZorgprofiel = x.Zorgprofiel?.ProfielCode != null && x.Zorgprofiel.ProfielCode != ProfielCode.Geen
                }).ToList();
        }

        model.AantalClienten = model.Clienten.Count();
        model.AantalClientenMetProfiel = model.Clienten.Count(x => x.HasZorgprofiel);

        return model;
    }
}