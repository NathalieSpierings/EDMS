using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Models;
using Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Queries;

namespace Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.QueryHandlers;

public class GetAanleverbestandCreateHandler : IQueryHandlerAsync<GetAanleverbestandCreate, AanleverbestandCreateViewModel>
{
    private readonly IAanleverbestandRepository _repository;
    private readonly IMedewerkerRepository _medewerkerRepository;

    public GetAanleverbestandCreateHandler(IAanleverbestandRepository repository, IMedewerkerRepository medewerkerRepository)
    {
        _repository = repository;
        _medewerkerRepository = medewerkerRepository;
    }

    public async Task<AanleverbestandCreateViewModel> HandleAsync(GetAanleverbestandCreate query)
    {
        var dbQuery = await _repository.Query().FirstOrDefaultAsync(x => x.Id == query.AanleverbestandId);

        var creator = dbQuery.AangemaaktDoor.HasValue ? await _medewerkerRepository.GetVolledigeNaamByIdAsync(dbQuery.AangemaaktDoor.Value) : string.Empty;
        var modifier = dbQuery.AangepastDoor.HasValue ? await _medewerkerRepository.GetVolledigeNaamByIdAsync(dbQuery.AangepastDoor.Value) : string.Empty;

        return new AanleverbestandCreateViewModel
        {
            Id = dbQuery.Id,
            Periode = dbQuery.Periode,
            WorkFlowState = dbQuery.WorkFlowState,
            Gecontroleerd = dbQuery.Gecontroleerd,
            VoorraadId = dbQuery.VoorraadId,
            AanleveringId = dbQuery.AanleveringId,
            FileName = dbQuery.FileName,
            FileSize = dbQuery.FileSize,
            Extension = dbQuery.Extension,
            MimeType = dbQuery.MimeType,
            Data = query.IncludeData ? dbQuery.Data : null,
            AangemaaktOp = dbQuery.AangemaaktOp,
            AangemaaktDoorNaam = creator,
            AangepastOp = dbQuery.AangepastOp,
            AangepastDoorNaam = modifier,
            EigenaarId = dbQuery.EigenaarId,
            ZorgstraatId = dbQuery.ZorgstraatId,
            Organisatie = new OrganisatieViewModel
            {
                Id = dbQuery.VoorraadId != null ? dbQuery.Voorraad.Organisatie.Id : dbQuery.Aanlevering.OrganisatieId,
                Nummer = dbQuery.VoorraadId != null ? dbQuery.Voorraad.Organisatie.Nummer : dbQuery.Aanlevering.Organisatie.Nummer,
                Naam = dbQuery.VoorraadId != null ? dbQuery.Voorraad.Organisatie.Naam : dbQuery.Aanlevering.Organisatie.Naam,
                VoorraadId = dbQuery.VoorraadId != null ? dbQuery.Voorraad.Id : Guid.Empty,
                Zorggroep = dbQuery.VoorraadId != null ? dbQuery.Voorraad.Organisatie.Zorggroep : dbQuery.Aanlevering.Organisatie.Zorggroep,
            }
        };
    }
}