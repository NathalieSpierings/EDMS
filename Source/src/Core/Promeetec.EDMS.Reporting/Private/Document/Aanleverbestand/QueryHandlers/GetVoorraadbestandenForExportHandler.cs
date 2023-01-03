using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Models;
using Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Queries;

namespace Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.QueryHandlers;

public class GetVoorraadbestandenForExportHandler : IQueryHandlerAsync<GetVoorraadbestandenForExport, VoorraadbestandenExportViewModel>
{
    private readonly IAanleverbestandRepository _repository;

    public GetVoorraadbestandenForExportHandler(IAanleverbestandRepository repository)
    {
        _repository = repository;
    }

    public async Task<VoorraadbestandenExportViewModel> HandleAsync(GetVoorraadbestandenForExport query)
    {
        await Task.CompletedTask;

        var model = new VoorraadbestandenExportViewModel
        {
            VoorraadId = query.VoorraadId,
            Voorraadbestanden = new List<VoorraadbestandExportListItemViewModel>()
        };

        var dbQuery = _repository.Query()
            .AsNoTracking()
            .Include(i => i.Eigenaar)
            .Include(i => i.Zorgstraat)
            .Include(i => i.Voorraad)
            .Include(i => i.Voorraad.Organisatie)
            .Where(x => x.VoorraadId == query.VoorraadId && x.WorkFlowState == AanleverbestandWorkflowState.Voorraad)
            .Select(x => new VoorraadbestandExportListItemViewModel
            {
                OrganisatieNummer = x.Aanlevering.Organisatie.Nummer,
                ZorgstraatNaam = x.Zorgstraat != null ? x.Zorgstraat.Naam : null,
                Periode = x.Periode,
                EigenaarVolledigeNaam = x.Eigenaar.Persoon.VolledigeNaam,
                EigenaarAgbCodeOnderneming = x.Eigenaar.AgbCodeOnderneming,
                EigenaarAgbCodeZorgverlener = x.Eigenaar.AgbCodeZorgverlener,
                FileName = x.FileName,
                AangemaaktOp = x.AangemaaktOp
            });

        model.Voorraadbestanden = dbQuery.OrderBy(o => o.AangemaaktOp);
        return model;
    }
}