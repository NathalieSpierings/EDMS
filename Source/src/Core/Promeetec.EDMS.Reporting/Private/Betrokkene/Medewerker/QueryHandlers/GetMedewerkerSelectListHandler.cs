using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.QueryHandlers;

public class GetMedewerkerSelectListHandler : IQueryHandlerAsync<GetMedewerkerSelectList, MedewerkerSelectList>
{
    private readonly IMedewerkerRepository _repository;
    private readonly IOrganisatieRepository _organisatieRepository;

    public GetMedewerkerSelectListHandler(IMedewerkerRepository repository, IOrganisatieRepository organisatieRepository)
    {
        _repository = repository;
        _organisatieRepository = organisatieRepository;
    }

    public async Task<MedewerkerSelectList> HandleAsync(GetMedewerkerSelectList query)
    {
        // Bepaal de organisatie id
        var organisatieId = query.FilterOpContactpersonen || query.FilterOpBehandelaren
            ? await _organisatieRepository.GetPromeetecIdAsync()
            : query.OrganisatieId.Value;

        var dbQuery = _repository.Query().AsNoTracking()
            .Where(x => x.OrganisatieId == organisatieId);


        // Toont een lijst van promeetec medewerkers
        if (query.FilterOpContactpersonen)
        {
            var contactPersonen = _repository.Query()
                .AsNoTracking()
                .Where(x => x.OrganisatieId == organisatieId &&
                            x.MedewerkerSoort == MedewerkerSoort.Intern &&
                            x.MedewerkerSoort != MedewerkerSoort.Privilege &&
                            x.Status == Status.Actief);

            if (query.ExcludedMedewerkerId != null && query.ExcludedMedewerkerId != Guid.Empty)
                contactPersonen = dbQuery.Where(x => x.Id != query.ExcludedMedewerkerId);

            var result = await contactPersonen
                .OrderBy(o => o.Persoon.Achternaam)
                .ToListAsync();

            return new MedewerkerSelectList
            {
                Medewerkers = new SelectList(result, "Id", "Persoon.VolledigeNaam")
            };
        }

        // Toont een lijst van promeetec medewerkers en zet de contactpersoon voor de gegeven organisatie (query.organisatieId is verplicht) als standaard selected
        if (query.FilterOpBehandelaren)
        {
            var organisatie = await _organisatieRepository.GetByIdAsync(query.OrganisatieId.Value);
            var temp = dbQuery.Where(x => x.MedewerkerSoort == MedewerkerSoort.Intern &&
                                          x.MedewerkerSoort != MedewerkerSoort.Privilege &&
                                          x.Status == Status.Actief);

            if (query.ExcludedMedewerkerId != null && query.ExcludedMedewerkerId != Guid.Empty)
                temp = dbQuery.Where(x => x.Id != query.ExcludedMedewerkerId);

            var result = await temp
                .OrderBy(o => o.Persoon.Achternaam)
                .ToListAsync();

            return new MedewerkerSelectList
            {
                Medewerkers = new SelectList(result, "Id", "Persoon.VolledigeNaam", organisatie.ContactpersoonId)
            };
        }


        // Toont een lijst van promeetec of externe medewerkers
        if (query.FilterOpEigenaren)
        {
            List<Domain.Models.Betrokkene.Medewerker.Medewerker> result;
            var isPromeetec = await _organisatieRepository.GetPromeetecIdAsync() == query.OrganisatieId;
            if (isPromeetec)
            {
                var temp = dbQuery.Where(x => x.Groups.Any(y => y.Group.Name == GroupNames.Declaratie) && x.Status == Status.Actief);

                if (query.ExcludedMedewerkerId != null && query.ExcludedMedewerkerId != Guid.Empty)
                    temp = dbQuery.Where(x => x.Id != query.ExcludedMedewerkerId);

                result = await temp
                    .OrderBy(o => o.Persoon.Achternaam)
                    .ToListAsync();
            }
            else
            {
                if (query.ExcludedMedewerkerId != null && query.ExcludedMedewerkerId != Guid.Empty)
                {
                    result = await dbQuery.Where(x => x.Groups.Any(y => y.Group.Name == GroupNames.TeamLevel2)
                                                      || x.Groups.Any(y => y.Group.Name == GroupNames.GliLevel2)
                                                      && x.Id != query.ExcludedMedewerkerId
                                                      && x.Status == Status.Actief)
                        .OrderBy(o => o.Persoon.Achternaam)
                        .ToListAsync();
                }
                else
                {
                    result = await dbQuery.Where(x => x.Groups.Any(y => y.Group.Name == GroupNames.TeamLevel2)
                                                      || x.Groups.Any(y => y.Group.Name == GroupNames.GliLevel2)
                                                      && x.Status == Status.Actief)
                        .OrderBy(o => o.Persoon.Achternaam)
                        .ToListAsync();
                }
            }

            return new MedewerkerSelectList
            {
                Medewerkers = new SelectList(result, "Id", "Persoon.VolledigeNaam")
            };
        }

        // Toont een lijst van adresboek collega's
        if (query.FilterOpAdresboekCollega)
        {
            var collegas = _repository.Query()
                .Include(i => i.Groups)
                .AsNoTracking()
                .Where(x => x.OrganisatieId == query.OrganisatieId &&
                            x.Groups.Any(y => y.Group.Name == GroupNames.AdresboekLevel0 ||
                                              y.Group.Name == GroupNames.AdresboekLevel1 ||
                                              y.Group.Name == GroupNames.AdresboekLevel2) &&
                            x.Status == Status.Actief);


            if (query.ExcludedMedewerkerId != null && query.ExcludedMedewerkerId != Guid.Empty)
                collegas = collegas.Where(x => x.Id != query.ExcludedMedewerkerId);

            var result = await collegas
                .OrderBy(o => o.Persoon.Achternaam)
                .ToListAsync();

            return new MedewerkerSelectList
            {
                Medewerkers = new SelectList(result, "Id", "Persoon.VolledigeNaam")
            };
        }
        else
        {
            // Toon een lijst van medewerkers
            var result = await dbQuery
                .Where(x => x.Status == Status.Actief)
                .OrderBy(o => o.Persoon.Achternaam)
                .ToListAsync();

            return new MedewerkerSelectList
            {
                Medewerkers = new SelectList(result, "Id", "Persoon.VolledigeNaam")
            };
        }
    }
}