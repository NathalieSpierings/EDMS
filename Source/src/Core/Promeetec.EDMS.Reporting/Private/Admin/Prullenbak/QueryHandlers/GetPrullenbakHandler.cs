using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Admin.RecycleBin.Models;
using Promeetec.EDMS.Reporting.Private.Admin.Prullenbak.Models;
using Promeetec.EDMS.Reporting.Private.Admin.Prullenbak.Queries;

namespace Promeetec.EDMS.Reporting.Private.Admin.Prullenbak.QueryHandlers;

public class GetPrullenbakHandler : IQueryHandlerAsync<GetPrullenbak, PrullenbakViewModel>
{
    private readonly IDispatcher _dispatcher;
    private readonly IOrganisatieRepository _organisatieRepository;
    private readonly IMedewerkerRepository _medewerkerRepository;
    private readonly IAanleveringRepository _aanleveringRepository;

    public GetPrullenbakHandler(IOrganisatieRepository organisatieRepository, IMedewerkerRepository medewerkerRepository, IAanleveringRepository aanleveringRepository)
    {
        _organisatieRepository = organisatieRepository;
        _medewerkerRepository = medewerkerRepository;
        _aanleveringRepository = aanleveringRepository;
    }


    public async Task<PrullenbakViewModel> HandleAsync(GetPrullenbak query)
    {
        await Task.CompletedTask;

        var list = new List<PrullenbakListItemViewModel>();

        var organisaties = _organisatieRepository.Query()
            .Where(x => x.Status == Status.Verwijderd)
            .AsNoTracking().Select(y => new PrullenbakListItemViewModel
            {
                Id = y.Id,
                Soort = PrullenbakSoort.Organisatie,
                Naam = string.Concat(y.Naam, "(", y.Nummer, ")"),
                VerwijderdOp = y.VerwijderdOp,
                VerwijderdDoorId = y.VerwijderdDoorId,
                VerwijderdDoor = y.VerwijderdDoorNaam
            });

        list.AddRange(organisaties);


        var medewerkers = _medewerkerRepository.Query()
            .Where(x => x.Status == Status.Verwijderd)
            .AsNoTracking().Select(y => new PrullenbakListItemViewModel
            {
                Id = y.Id,
                Soort = PrullenbakSoort.Medewerker,
                Naam = y.Persoon.VolledigeNaam,
                VerwijderdOp = y.VerwijderdOp,
                VerwijderdDoorId = y.VerwijderdDoorId,
                VerwijderdDoor = y.VerwijderdDoorNaam
            });

        list.AddRange(medewerkers);


        var aanleveringen = _aanleveringRepository.Query()
            .Where(x => x.Status == Status.Verwijderd)
            .AsNoTracking().Select(y => new PrullenbakListItemViewModel
            {
                Id = y.Id,
                Soort = PrullenbakSoort.Aanlevering,
                Naam = y.ReferentiePromeetec,
                VerwijderdOp = y.VerwijderdOp,
                VerwijderdDoorId = y.VerwijderdDoorId,
                VerwijderdDoor = y.VerwijderdDoorNaam
            });

        list.AddRange(aanleveringen);

        var model = new PrullenbakViewModel
        {
            PrullenbakItems = list
        };

        return model;
    }
}