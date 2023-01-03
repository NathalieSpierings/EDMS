using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Voorraad;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Extensions;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Document.Rapportage.Dashboard.Queries;
using Promeetec.EDMS.Reporting.Modules.Declaratie.Dashboard.Models;
using Promeetec.EDMS.Reporting.Modules.Verbruiksmiddel.Dashboard.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.QueryHandlers;

public class GetOrganisatieDashboardHandler : IQueryHandlerAsync<GetOrganisatieDashboard, OrganisatieDashboardViewModel>
{
    private readonly IDispatcher _dispatcher;
    private readonly IAanleveringRepository _aanleveringRepository;
    private readonly IVoorraadRepository _voorraadRepository;
    private readonly IVerbruiksmiddelPrestatieRepository _verbruiksmiddelPrestatieRepository;
    private readonly IMedewerkerRepository _medewerkerRepository;

    public GetOrganisatieDashboardHandler(IDispatcher dispatcher, IVoorraadRepository voorraadRepository, IAanleveringRepository aanleveringRepository, IVerbruiksmiddelPrestatieRepository verbruiksmiddelPrestatieRepository, IMedewerkerRepository medewerkerRepository)
    {
        _dispatcher = dispatcher;
        _voorraadRepository = voorraadRepository;
        _aanleveringRepository = aanleveringRepository;
        _verbruiksmiddelPrestatieRepository = verbruiksmiddelPrestatieRepository;
        _medewerkerRepository = medewerkerRepository;
    }

    public async Task<OrganisatieDashboardViewModel> HandleAsync(GetOrganisatieDashboard query)
    {
        bool showDeclaratiesDashboard;
        bool showVerbruiksmiddelenDashboard;

        var model = new OrganisatieDashboardViewModel
        {
            OrganisatieId = query.OrganisatieId,
            VoorraadId = query.VoorraadId,
            AdresboekId = query.AdresboekId,
            DeclaratieDashboard = new DeclaratieDashboardViewModel(),
            VerbruiksmiddelenDashboard = new VerbruiksmiddelenDashboardViewModel()
        };

        // Toon het dashboard zoals de klant het ziet als Level2 user
        if (query.User.IsInterneMedewerker)
        {
            showDeclaratiesDashboard = await _medewerkerRepository.Query().Where(x => x.OrganisatieId == query.OrganisatieId && x.Groups.Any(g => g.Group.Name == GroupNames.TeamLevel2)).FirstOrDefaultAsync() != null;
            showVerbruiksmiddelenDashboard = await _medewerkerRepository.Query().Where(x => x.OrganisatieId == query.OrganisatieId && x.Groups.Any(g => g.Group.Name == GroupNames.VerbruiksmiddelenLevel2)).FirstOrDefaultAsync() != null;
        }
        else
        {
            showDeclaratiesDashboard = query.User.IsInRole(RoleNames.RaadplegenAanleveringen);
            showVerbruiksmiddelenDashboard = query.User.IsInRole(RoleNames.RaadplegenVerbruiksmiddelPrestaties);
        }

        model.ShowDeclaratieDashboard = showDeclaratiesDashboard;
        model.ShowVerbruiksmiddelenDashboard = showVerbruiksmiddelenDashboard;

        if (showDeclaratiesDashboard)
        {
            // Haal de aanleveringen op van de gegeven medewerker
            var dbQueryAanleveringen = _aanleveringRepository.Query()
                .Include(i => i.Aanleverbestanden)
                .AsNoTracking()
                .Where(x => x.OrganisatieId == query.OrganisatieId && x.Status != Status.Verwijderd)
                .Select(x => new DashboardAanleveringenDto
                {
                    Id = x.Id,
                    Referentie = x.Referentie,
                    ReferentiePromeetec = x.ReferentiePromeetec,
                    Aanleverdatum = x.Aanleverdatum,
                    AanleverStatus = x.AanleverStatus
                });

            if (query.User.IsInRole(RoleNames.RaadplegenEigenAanleverbestanden))
            {
                dbQueryAanleveringen = _aanleveringRepository.Query()
                    .Include(i => i.Aanleverbestanden)
                    .AsNoTracking()
                    .Where(x => x.OrganisatieId == query.OrganisatieId && x.Status != Status.Verwijderd && x.Aanleverbestanden.Any(b => b.EigenaarId == query.User.Id))
                    .Select(x => new DashboardAanleveringenDto
                    {
                        Id = x.Id,
                        Referentie = x.Referentie,
                        ReferentiePromeetec = x.ReferentiePromeetec,
                        Aanleverdatum = x.Aanleverdatum,
                        AanleverStatus = x.AanleverStatus,
                        Aanleverbestanden = x.Aanleverbestanden.Select(c => new AanleverbestandenDto
                        {
                            Id = c.Id,
                            EigenaarId = c.EigenaarId
                        }).ToList()
                    });
            }

            if (query.StartDatum != DateTime.MinValue)
                dbQueryAanleveringen = dbQueryAanleveringen.Where(x => x.Aanleverdatum >= query.StartDatum);

            if (query.EindDatum != DateTime.MinValue)
                dbQueryAanleveringen = dbQueryAanleveringen.Where(x => x.Aanleverdatum <= query.EindDatum);



            // Vul recente aanleveringen (max 15)
            model.DeclaratieDashboard.Aanleveringen = dbQueryAanleveringen.OrderBy(o => o.Aanleverdatum)
                .SelectPage(x => x.Aanleverdatum, true, query.PageIndex.Value, query.PageSize.Value)
                .Select(x => new WidgetAanleveringenListItemViewModel
                {
                    AanleveringId = x.Id,
                    Referentie = query.User.IsInterneMedewerker ? x.ReferentiePromeetec : x.Referentie,
                    AanleverStatus = x.AanleverStatus,
                    Aanleverdatum = x.Aanleverdatum
                }).ToList();



            // Stats
            model.DeclaratieDashboard.AantalActiveAanleveringen = await dbQueryAanleveringen.CountAsync(x => x.AanleverStatus != AanleverStatus.Afgekeurd && x.AanleverStatus != AanleverStatus.Verwerkt);
            model.DeclaratieDashboard.AantalAfgehandeldeAanleveringen = await dbQueryAanleveringen.CountAsync(x => x.AanleverStatus == AanleverStatus.Afgekeurd || x.AanleverStatus == AanleverStatus.Verwerkt);
            model.DeclaratieDashboard.AantalVoorraadbestanden = await _voorraadRepository.AantalVoorraadbestandenAsync(query.VoorraadId, query.User.IsInRole(RoleNames.RaadplegenEigenAanleverbestanden), query.User.Id);
            model.DeclaratieDashboard.AantalAanleveringen = await dbQueryAanleveringen.CountAsync();


            // Gauge
            model.DeclaratieDashboard.Gauge = new GaugeAanleverstatusViewModel
            {
                Totaal = await dbQueryAanleveringen.CountAsync(),
                Aangemaakt = await dbQueryAanleveringen.CountAsync(x => x.AanleverStatus == AanleverStatus.Aangemaakt),
                InBehandeling = await dbQueryAanleveringen.CountAsync(x => x.AanleverStatus == AanleverStatus.InBehandeling),
                Ingediend = await dbQueryAanleveringen.CountAsync(x => x.AanleverStatus == AanleverStatus.Ingediend),
                Verwerkt = await dbQueryAanleveringen.CountAsync(x => x.AanleverStatus == AanleverStatus.Verwerkt),
                Afgekeurd = await dbQueryAanleveringen.CountAsync(x => x.AanleverStatus == AanleverStatus.Afgekeurd),
            };

            // Recente declaratie rapportage (max 15)
            model.DeclaratieDashboard.Rapportages = await _dispatcher.GetResultAsync(new GetRapportageDashboardWidget
            {
                OrganisatieId = query.OrganisatieId,
                User = query.User,
                StartDatum = query.StartDatum,
                EindDatum = query.EindDatum,
                PageIndex = 0,
                PageSize = 15
            });

        }

        if (showVerbruiksmiddelenDashboard)
        {
            // Registratie widgets
            var dbQueryVerbruiksmiddelPrestaties = _verbruiksmiddelPrestatieRepository.Query()
                .AsNoTracking()
                .Where(x => x.OrganisatieId == query.OrganisatieId);

            // Alleen prestaties van de eigenaar mogen getoond worden
            if (query.User.IsInRole(RoleNames.RaadplegenEigenVerbruiksmiddelPrestaties))
                dbQueryVerbruiksmiddelPrestaties = dbQueryVerbruiksmiddelPrestaties.Where(x => x.AangemaaktDoorId == query.User.Id);

            // Stats
            model.VerbruiksmiddelenDashboard.AantalNieuwePrestaties = await dbQueryVerbruiksmiddelPrestaties.CountAsync(x => x.Status == VerbruiksmiddelPrestatieStatus.Nieuw);
            model.VerbruiksmiddelenDashboard.AantalVerwerktePrestaties = await dbQueryVerbruiksmiddelPrestaties.CountAsync(x => x.Status == VerbruiksmiddelPrestatieStatus.Verwerkt);


            // Recente verbruiksmiddelen rapportage (max 15)
            model.VerbruiksmiddelenDashboard.Rapportages = await _dispatcher.GetResultAsync(new GetRapportageDashboardWidget
            {
                OrganisatieId = query.OrganisatieId,
                User = query.User,
                StartDatum = query.StartDatum,
                EindDatum = query.EindDatum,
                PageIndex = 0,
                PageSize = 15
            });
        }

        return model;
    }
}