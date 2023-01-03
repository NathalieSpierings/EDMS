using System;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Modules.Ketenzorg;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.QueryHandlers;

public class GetMachtigingRegistratiesHandler : IQueryHandlerAsync<GetMachtigingRegistraties, MachtigingRegistratiesViewModel>
{
    private readonly IDispatcher _dispatcher;

    public GetMachtigingRegistratiesHandler(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    public async Task<MachtigingRegistratiesViewModel> HandleAsync(GetMachtigingRegistraties query)
    {
        var machtiging = await _dispatcher.GetResultAsync(new GetMachtiging
        {
            MachtigingId = query.MachtigingId,
            OrganisatieId = query.OrganisatieId,
            OrganisatieNaam = query.OrganisatieNaam,
            OrganisatieNummer = query.OrganisatieNummer,
            IncludeRegistraties = true
        });

        var model = new MachtigingRegistratiesViewModel
        {
            Machtiging = machtiging,
            NewRegistrationsAllowed = machtiging.Product.ActiviteitGroepen.Any(x => x.ResterendAantal > 0)
                                      && machtiging.Status == MachtigingStatus.Open
                                      && (!machtiging.Einddatum.HasValue || machtiging.Einddatum.Value >= DateTime.Today)
        };

        // Zoeken
        if (!string.IsNullOrWhiteSpace(query.SearchTerm))
        {
            var matchWoorden = query.SearchTerm.ToLower().Split(' ');
            foreach (var match in matchWoorden)
            {
                if (match == "ja")
                {
                    model.Machtiging.Registraties = model.Machtiging.Registraties.Where(x => x.Verwerkt).ToList();
                }
                else if (match == "nee")
                {
                    model.Machtiging.Registraties = model.Machtiging.Registraties.Where(x => x.Verwerkt == false).ToList();
                }
                else if (DateTime.TryParse(match, out var date))
                {
                    model.Machtiging.Registraties = model.Machtiging.Registraties.Where(x => x.Behandeldatum.ToShortDateString() == date.ToShortDateString()).ToList();
                }
                else
                {
                    model.Machtiging.Registraties = model.Machtiging.Registraties.Where(x => model.Machtiging.Registraties.Any(y => x.Naam.ToLowerInvariant().Contains(match)) ||
                                                                                             model.Machtiging.Registraties.Any(y => x.Aantal.ToString().Contains(match)) ||
                                                                                             model.Machtiging.Registraties.Any(y => x.Eenheid.ToString().Contains(match))).ToList();
                }
            }
        }

        return model;
    }
}