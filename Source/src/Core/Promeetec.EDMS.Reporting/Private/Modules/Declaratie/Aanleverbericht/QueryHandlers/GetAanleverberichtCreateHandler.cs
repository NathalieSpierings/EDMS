using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanleverbericht.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanleverbericht.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanleverbericht.QueryHandlers;

/// <summary>
/// Haalt een enkel bericht met bijbehorede replies op.
/// </summary>
public class GetAanleverberichtCreateHandler : IQueryHandlerAsync<GetAanleverberichtCreate, AanleverberichtCreateViewModel>
{
    private readonly IDispatcher _dispatcher;
    private readonly IAanleveringRepository _aanleveringRepository;
    private readonly IMedewerkerRepository _medewerkerRepository;

    public GetAanleverberichtCreateHandler(IDispatcher dispatcher, IAanleveringRepository aanleveringRepository, IMedewerkerRepository medewerkerRepository)
    {
        _dispatcher = dispatcher;
        _aanleveringRepository = aanleveringRepository;
        _medewerkerRepository = medewerkerRepository;
    }

    public async Task<AanleverberichtCreateViewModel> HandleAsync(GetAanleverberichtCreate query)
    {
        var aanlevering = await _aanleveringRepository.Query()
            .AsNoTracking()
            .Include(i => i.Organisatie)
            .Include(i => i.Eigenaar)
            .Include(i => i.Behandelaar)
            .Where(x => x.Id == query.AanleveringId).FirstOrDefaultAsync();


        var afzender = await _medewerkerRepository.Query()
            .Where(x => x.Id == query.User.Id)
            .Select(x => new MedewerkerViewModel
            {
                Id = x.Id,
                Avatar = x.Avatar,
                VolledigeNaam = x.Persoon.VolledigeNaam,
                Geslacht = x.Persoon.Geslacht
            }).FirstOrDefaultAsync();

        var ontvangerId = query.User.IsInterneMedewerker ? aanlevering.EigenaarId : aanlevering.Behandelaar.Id;
        var ontvanger = await _medewerkerRepository.Query()
            .Where(x => x.Id == ontvangerId)
            .Select(x => new MedewerkerViewModel
            {
                Id = x.Id,
                Avatar = x.Avatar,
                VolledigeNaam = x.Persoon.VolledigeNaam,
                Geslacht = x.Persoon.Geslacht
            }).FirstOrDefaultAsync();


        var model = new AanleverberichtCreateViewModel
        {
            AanleveringId = query.AanleveringId,
            OrganisatieId = query.OrganisatieId,
            Referentie = query.User.IsInterneMedewerker ? aanlevering.ReferentiePromeetec : aanlevering.Referentie,
            OrganisatieDisplayName = aanlevering.Organisatie.DisplayName,
            Afzender = afzender,
            Ontvanger = ontvanger,
        };

        return model;
    }
}