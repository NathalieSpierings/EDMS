using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Document.Overigbestand;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Private.Document.Overigbestand.Models;
using Promeetec.EDMS.Reporting.Private.Document.Overigbestand.Queries;

namespace Promeetec.EDMS.Reporting.Private.Document.Overigbestand.QueryHandlers;

public class GetOverigbestandHandler : IQueryHandlerAsync<GetOverigbestand, OverigbestandViewModel>
{
    private readonly IOverigbestandRepository _repository;
    private readonly IMedewerkerRepository _medewerkerRepository;

    public GetOverigbestandHandler(IOverigbestandRepository repository, IMedewerkerRepository medewerkerRepository)
    {
        _repository = repository;
        _medewerkerRepository = medewerkerRepository;
    }

    public async Task<OverigbestandViewModel> HandleAsync(GetOverigbestand query)
    {
        var model = await _repository
            .Query()
            .AsNoTracking()
            .Where(x => x.Id == query.OverigbestandId)
            .Select(x => new OverigbestandViewModel
            {
                Id = x.Id,
                AanleveringId = x.AanleveringId,
                FileName = x.FileName,
                Files = new FilesViewModel
                {
                    OrganisatieId = x.Aanlevering.OrganisatieId,
                    UploadType = UploadType.Overigbestand
                },
                Organisatie = new OrganisatieViewModel
                {
                    Id = x.Aanlevering.OrganisatieId,
                    Nummer = x.Aanlevering.Organisatie.Nummer,
                    Naam = x.Aanlevering.Organisatie.Naam,
                    VoorraadId = x.Aanlevering.Organisatie.Voorraad.Id,
                    Zorggroep = x.Aanlevering.Organisatie.Zorggroep,
                },
                EigenaarId = x.EigenaarId,
            }).FirstOrDefaultAsync();


        var organisatieMedewerkers = await _medewerkerRepository.GetMedewerkersByOrganisatieIdAsync(query.OrganisatieId);
        model.Eigenaren = new SelectList(organisatieMedewerkers, "Id", "VolledigeNaam");

        return model;
    }
}