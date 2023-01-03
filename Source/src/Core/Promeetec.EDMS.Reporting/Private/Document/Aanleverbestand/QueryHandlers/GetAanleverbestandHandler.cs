using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Admin.Zorgstraat.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Medewerker.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Models;
using Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Queries;

namespace Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.QueryHandlers;

public class GetAanleverbestandHandler : IQueryHandlerAsync<GetAanleverbestand, AanleverbestandViewModel>
{
    private readonly IDispatcher _dispatcher;
    private readonly IAanleverbestandRepository _repository;
    private readonly IMedewerkerRepository _medewerkerRepository;

    public GetAanleverbestandHandler(IDispatcher dispatcher, IAanleverbestandRepository repository, IMedewerkerRepository medewerkerRepository)
    {
        _dispatcher = dispatcher;
        _repository = repository;
        _medewerkerRepository = medewerkerRepository;
    }

    public async Task<AanleverbestandViewModel> HandleAsync(GetAanleverbestand query)
    {
        var model = await _repository
            .Query()
            .AsNoTracking()
            .Where(x => x.Id == query.AanleverbestandId)
            .Select(x => new AanleverbestandViewModel
            {
                Id = x.Id,
                Periode = x.Periode,
                WorkFlowState = x.WorkFlowState,
                Gecontroleerd = x.Gecontroleerd,
                ZorgstraatId = x.ZorgstraatId,
                Zorgstraat = new ZorgstraatViewModel
                {
                    Id = x.ZorgstraatId ?? Guid.Empty,
                    Naam = x.Zorgstraat.Naam
                },
                VoorraadId = x.VoorraadId,
                AanleveringId = x.AanleveringId,
                FileName = x.FileName,
                FileSize = x.FileSize,
                Extension = x.Extension,
                MimeType = x.MimeType,
                AangemaaktOp = x.AangemaaktOp,
                AangemaaktDoorId = x.AangemaaktDoor.Value,
                AangepastOp = x.AangepastOp,
                AangepastDoorId = x.AangepastDoor.Value,
                Eigenaar = new MedewerkerViewModel
                {
                    Id = x.EigenaarId
                },
                Organisatie = new OrganisatieViewModel
                {
                    Id = x.VoorraadId != null && x.VoorraadId != Guid.Empty ? x.Voorraad.Organisatie.Id : x.Aanlevering.OrganisatieId,
                    Nummer = x.VoorraadId != null ? x.Voorraad.Organisatie.Nummer : x.Aanlevering.Organisatie.Nummer,
                    Naam = x.VoorraadId != null ? x.Voorraad.Organisatie.Naam : x.Aanlevering.Organisatie.Naam,
                    VoorraadId = x.VoorraadId != null ? x.Voorraad.Id : Guid.Empty,
                    Zorggroep = x.VoorraadId != null ? x.Voorraad.Organisatie.Zorggroep : x.Aanlevering.Organisatie.Zorggroep,
                },
                Samenvatting = new AanleverbestandSamenvattingViewModel
                {
                    Id = x.Samenvatting != null ? x.Samenvatting.Id : Guid.Empty,
                    AanleverbestandId = x.Id,
                    EiStandaard = x.Samenvatting != null ? x.Samenvatting.EiStandaard : string.Empty,
                    AantalVerzekerdeRecords = x.Samenvatting != null ? x.Samenvatting.AantalVerzekerdeRecords : 0,
                    AantalPrestatierecords = x.Samenvatting != null ? x.Samenvatting.AantalPrestatieRecords : 0,
                    Totaalbedrag = x.Samenvatting != null ? x.Samenvatting.TotaalDeclaratiebedrag : 0,
                    AgbCodeZorgverlener = x.Samenvatting != null ? x.Samenvatting.ZorgverlenersCode : 0,
                    AgbCodeOnderneming = x.Samenvatting != null ? x.Samenvatting.Instellingscode : 0,
                    AgbCodePraktijk = x.Samenvatting != null ? x.Samenvatting.Praktijkcode : 0,
                    Processed = x.Samenvatting != null && x.Samenvatting.Processed,
                    OvergeslagenRows = x.Samenvatting != null ? x.Samenvatting.OvergeslagenRows : 0
                }
            }).FirstOrDefaultAsync();


        model.AangemaaktDoor = model.AangemaaktDoorId.HasValue ? await _medewerkerRepository.GetVolledigeNaamByIdAsync(model.AangemaaktDoorId.Value) : string.Empty;
        model.AangepastDoor = model.AangepastDoorId.HasValue ? await _medewerkerRepository.GetVolledigeNaamByIdAsync(model.AangepastDoorId.Value) : string.Empty;

        var eigenaar = await _dispatcher.GetResultAsync(new GetMedewerker
        {
            MedewerkerId = model.Eigenaar.Id,
            IncludeProfile = true
        });

        model.Eigenaar = eigenaar;

        return model;
    }
}