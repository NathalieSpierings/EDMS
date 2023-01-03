using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Modules.Declaratie.Aanlevering.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanleverbericht.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanleverbericht.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanleverbericht.QueryHandlers;

/// <summary>
/// Er zijn 3 smaken:
/// Alle berichten van alle aanleveringen van alle behandelaren.
/// Alle berichten voor gegeven aanlevering.
/// Alle berichten voor gegeven behandelaar.
/// </summary>
/// <seealso cref="AanleverberichtenViewModel" />
public class GetAanleverberichtenHandler : IQueryHandlerAsync<GetAanleverberichten, AanleverberichtenViewModel>
{
    private readonly IAanleverberichtRepository _repository;

    public GetAanleverberichtenHandler(IAanleverberichtRepository repository)
    {
        _repository = repository;
    }

    public async Task<AanleverberichtenViewModel> HandleAsync(GetAanleverberichten query)
    {
        await Task.CompletedTask;

        var model = new AanleverberichtenViewModel
        {
            Aanlevering = new AanleveringViewModel
            {
                Id = query.AanleveringId ?? Guid.Empty
            }
        };

        IEnumerable<AanleverberichtenDto> dbQuery;

        if (query.AanleveringId != null && query.AanleveringId != Guid.Empty)
        {
            // Haal alle berichten op voor gegeven aanlevering
            dbQuery = _repository.GetAlleAanleverberichtenVanAanlevering(query.AanleveringId.Value);
        }
        else if (query.BehandelaarId != null && query.BehandelaarId != Guid.Empty)
        {
            // Haal alle berichten op voor gegeven behandelaar
            dbQuery = _repository.GetAlleAanleverberichtenVanBehandelaar(query.BehandelaarId.Value);
        }
        else
        {
            // Haal alle berichten op van alle aanleveringen van alle organisaties
            dbQuery = _repository.GetAlleAanleverberichten();
        }

        // Zoeken
        if (!string.IsNullOrWhiteSpace(query.SearchTerm))
        {
            var matchWoorden = query.SearchTerm.ToLower().Split(' ');
            foreach (var match in matchWoorden)
            {
                if (DateTime.TryParse(match, out var aangemaaktOpDate))
                {
                    dbQuery = dbQuery.Where(x => x.GeplaatstOp.ToShortDateString() == aangemaaktOpDate.ToShortDateString()).ToList();
                }
                else
                {
                    dbQuery = dbQuery.Where(x => x.Onderwerp.Contains(match) ||
                                                 x.Onderwerp.Contains(match) ||
                                                 x.Bericht.Contains(match) ||
                                                 x.ReferentiePromeetec.Contains(match) ||
                                                 x.BehandelaarVolledigeNaam.Contains(match) ||
                                                 x.AfzenderVolledigeNaam.Contains(match));
                }
            }
        }

        model.Aanleverberichten = PopulateBerichten(dbQuery, null);
        model.AantalAanleverberichten = model.Aanleverberichten.Count(x => x.ParentId == null);

        return model;
    }

    private List<AanleverberichtListItemViewModel> PopulateBerichten(IEnumerable<AanleverberichtenDto> source, Guid? parentId)
    {
        var result = new List<AanleverberichtListItemViewModel>();

        foreach (var bericht in source.Where(x => x.ParentId == parentId).OrderBy(x => x.Volgorde))
        {
            var model = new AanleverberichtListItemViewModel
            {
                Id = bericht.Id,
                ParentId = bericht.ParentId,
                SortOrder = bericht.Volgorde,
                Read = bericht.Gelezen,
                Subject = bericht.Onderwerp,
                Message = bericht.Bericht,
                AanleverberichtStatus = bericht.AanleverberichtStatus,
                AangemaaktOp = bericht.GeplaatstOp,
                LaatstGelezenOp = bericht.LaatstGelezenOp,
                Aanlevering = new AanleveringViewModel
                {
                    Id = bericht.AanleveringId,
                    ReferentiePromeetec = bericht.ReferentiePromeetec,
                    Organisatie = new OrganisatieViewModel
                    {
                        Id = bericht.OrganisatieId,
                    },
                    Behandelaar = new MedewerkerViewModel
                    {
                        Id = bericht.BehandelaarId.Value,
                        Organisatie = new OrganisatieViewModel
                        {
                            Id = bericht.BehandelaarOrganisatieId,
                        },
                        FormeleNaam = bericht.BehandelaarFormeleNaam
                    }
                },
                Afzender = new MedewerkerViewModel
                {
                    Id = bericht.AfzenderId,
                    Organisatie = new OrganisatieViewModel
                    {
                        Id = bericht.AfzenderOrganisatieId,
                    },
                    FormeleNaam = bericht.AfzenderFormeleNaam,
                },
                Ontvanger = new MedewerkerViewModel
                {
                    Id = bericht.OntvangerId
                },
                LaatsteLezer = bericht.LaatsteLezerId != null && bericht.LaatsteLezerId != Guid.Empty ?
                    new MedewerkerViewModel
                    {
                        Id = bericht.LaatsteLezerId.Value,
                        VolledigeNaam = bericht.LaatsteLezerVolledigeNaam
                    }
                    : new MedewerkerViewModel()
            };

            model.Replies.AddRange(PopulateBerichten(source, bericht.Id));
            result.Add(model);
        }

        return result;
    }
}