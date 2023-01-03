using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Models;
using Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Queries;

namespace Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.QueryHandlers;

public class GetAanleverbestandenHandler : IQueryHandlerAsync<GetAanleverbestanden, AanleverbestandenViewModel>
{
    private readonly IAanleverbestandRepository _repository;

    public GetAanleverbestandenHandler(IAanleverbestandRepository repository)
    {
        _repository = repository;
    }

    public async Task<AanleverbestandenViewModel> HandleAsync(GetAanleverbestanden query)
    {
        await Task.CompletedTask;

        var model = new AanleverbestandenViewModel
        {
            AanleveringId = query.AanleveringId ?? Guid.Empty,
            Aanleverbestanden = new List<AanleverbestandListItemViewModel>()
        };

        if (query.User.IsInRole(RoleNames.RaadplegenAanleverbestanden))
        {
            var dbQuery = _repository.Query().AsNoTracking()
                .Where(x =>
                    query.VoorraadId != null
                        ? x.WorkFlowState == AanleverbestandWorkflowState.Voorraad && x.VoorraadId == query.VoorraadId
                        : x.WorkFlowState == AanleverbestandWorkflowState.Aanlevering && x.AanleveringId == query.AanleveringId)
                .Select(x => new AanleverbestandListItemViewModel
                {
                    Id = x.Id,
                    Periode = x.Periode,
                    Gecontroleerd = x.Gecontroleerd,
                    FileName = x.FileName,
                    Extension = x.Extension,
                    AangemaaktOp = x.AangemaaktOp,
                    EigenaarId = x.EigenaarId,
                    EigenaarFormeleNaam = x.Eigenaar.Persoon.FormeleNaam,
                    EigenaarVolledigeNaam = x.Eigenaar.Persoon.VolledigeNaam,
                    EigenaarAgbCode = x.Eigenaar.AgbCodeZorgverlener,
                    OrganisatieId = x.Eigenaar.OrganisatieId,
                    OrganisatieNummer = x.Eigenaar.Organisatie.Nummer,
                    ZorgstraatId = x.ZorgstraatId ?? default(Guid),
                    ZorgstraatNaam = x.Zorgstraat.Naam
                });

            model.Aanleverbestanden = dbQuery.OrderBy(o => o.AangemaaktOp);
            return model;
        }

        if (query.User.IsInRole(RoleNames.RaadplegenEigenAanleverbestanden))
        {
            var dbQuery = _repository.Query().AsNoTracking()
                .Where(x => query.VoorraadId != null ?
                    x.WorkFlowState == AanleverbestandWorkflowState.Voorraad &&
                    x.VoorraadId == query.VoorraadId &&
                    x.EigenaarId == query.User.Id :
                    x.WorkFlowState == AanleverbestandWorkflowState.Aanlevering &&
                    x.AanleveringId == query.AanleveringId &&
                    x.EigenaarId == query.User.Id)
                .Select(x => new AanleverbestandListItemViewModel
                {
                    Id = x.Id,
                    Periode = x.Periode,
                    Gecontroleerd = x.Gecontroleerd,
                    FileName = x.FileName,
                    Extension = x.Extension,
                    AangemaaktOp = x.AangemaaktOp,
                    EigenaarId = x.EigenaarId,
                    EigenaarFormeleNaam = x.Eigenaar.Persoon.FormeleNaam,
                    EigenaarVolledigeNaam = x.Eigenaar.Persoon.VolledigeNaam,
                    EigenaarAgbCode = x.Eigenaar.AgbCodeZorgverlener,
                    OrganisatieId = x.Eigenaar.OrganisatieId,
                    OrganisatieNummer = x.Eigenaar.Organisatie.Nummer,
                    ZorgstraatId = x.ZorgstraatId ?? default(Guid),
                    ZorgstraatNaam = x.Zorgstraat.Naam
                });

            model.Aanleverbestanden = dbQuery.OrderBy(o => o.AangemaaktOp);
            return model;
        }

        return model;
    }
}