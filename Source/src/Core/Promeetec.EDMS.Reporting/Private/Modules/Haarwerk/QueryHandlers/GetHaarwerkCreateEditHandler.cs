﻿using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Modules.Haarwerk;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Haarwerk.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Haarwerk.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.Haarwerk.QueryHandlers;

public class GetHaarwerkCreateEditHandler : IQueryHandlerAsync<GetHaarwerkCreateEdit, HaarwerkCreateEditViewModel>
{
    private readonly IHaarwerkRepository _repository;

    public GetHaarwerkCreateEditHandler(IHaarwerkRepository repository)
    {
        _repository = repository;
    }

    public async Task<HaarwerkCreateEditViewModel> HandleAsync(GetHaarwerkCreateEdit query)
    {
        var model = await _repository.Query()
           .Where(x => x.Id == query.HaarwerkId && x.OrganisatieId == query.OrganisatieId)
           .Select(x => new HaarwerkCreateEditViewModel
           {
               Id = x.Id,
               OrganisatieId = x.OrganisatieId,
               Naam = x.Naam,
               Geboortedatum = x.Geboortedatum,
               Bsn = x.Bsn,
               Verzekeringsnummer = x.Verzekeringsnummer,
               Machtigingsnummer = x.Machtigingsnummer,
               TypeHulpmiddel = x.TypeHulpmiddel,
               LeveringSoort = x.LeveringSoort,
               HaarwerkSoort = x.HaarwerkSoort,
               Afleverdatum = x.Afleverdatum,
               DatumVoorgaandHulpmiddel = x.DatumVoorgaandHulpmiddel,
               DatumMedischVoorschrift = x.DatumMedischVoorschrift,
               PrijsHaarwerk = x.PrijsHaarwerk,
               BedragBasisVerzekering = x.BedragBasisVerzekering,
               BedragAanvullendeVerzekering = x.BedragAanvullendeVerzekering,
               BedragEigenBijdragen = x.BedragEigenBijdragen,
               BedragTeOntvangen = x.BedragTeOntvangen,
               Status = x.Status,
               CreditType = x.CreditType
           }).FirstOrDefaultAsync();

        return model;
    }
}