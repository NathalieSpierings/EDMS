using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Models;
using Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Queries;

namespace Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.QueryHandlers;

public class GetAanleverbestandenForExportHandler : IQueryHandlerAsync<GetAanleverbestandenForExport, AanleverbestandenExportViewModel>
{
    private readonly IAanleverbestandRepository _repository;

    public GetAanleverbestandenForExportHandler(IAanleverbestandRepository repository)
    {
        _repository = repository;
    }

    public async Task<AanleverbestandenExportViewModel> HandleAsync(GetAanleverbestandenForExport query)
    {
        await Task.CompletedTask;

        var model = new AanleverbestandenExportViewModel
        {
            AanleveringId = query.AanleveringId,
            Aanleverbestanden = new List<AanleverbestandExportListItemViewModel>()
        };

        var dbQuery = _repository.Query()
            .AsNoTracking()
            .Include(i => i.Aanlevering)
            .Include(i => i.Aanlevering.Organisatie)
            .Include(i => i.Aanlevering.Eigenaar)
            .Where(x => x.AanleveringId == query.AanleveringId && x.WorkFlowState == AanleverbestandWorkflowState.Aanlevering)
            .Select(x => new AanleverbestandExportListItemViewModel
            {
                OrganisatieNummer = x.Aanlevering.Organisatie.Nummer,
                ReferentiePromeetec = x.Aanlevering.ReferentiePromeetec,
                ZorgstraatNaam = x.Zorgstraat != null ? x.Zorgstraat.Naam : null,
                Periode = x.Periode,
                EigenaarVolledigeNaam = x.Eigenaar.Persoon.VolledigeNaam,
                EigenaarAgbCodeOnderneming = x.Eigenaar.AgbCodeOnderneming,
                EigenaarAgbCodeZorgverlener = x.Eigenaar.AgbCodeZorgverlener,
                FileName = x.FileName,
                AangemaaktOp = x.AangemaaktOp
            });

        model.Aanleverbestanden = dbQuery.OrderBy(o => o.AangemaaktOp);
        return model;
    }
}