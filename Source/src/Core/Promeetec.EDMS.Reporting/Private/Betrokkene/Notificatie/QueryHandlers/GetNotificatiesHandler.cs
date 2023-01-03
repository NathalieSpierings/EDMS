using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.Notificatie;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Notificatie.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Notificatie.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Notificatie.QueryHandlers;

public class GetNotificatiesHandler : IQueryHandlerAsync<GetNotificaties, NotificatiesViewModel>
{
    private readonly INotificatieRepository _repository;
    public GetNotificatiesHandler(INotificatieRepository repository)
    {
        _repository = repository;
    }

    public async Task<NotificatiesViewModel> HandleAsync(GetNotificaties query)
    {
        var dbQuery = _repository.Query()
            .AsNoTracking()
            .Where(x => x.MedewerkerId == query.MedewerkerId &&
                        x.Medewerker.OrganisatieId == query.OrganisatieId);


        if (query.All != true)
        {
            dbQuery = dbQuery
                .Where(x => x.Datum >= DateTime.Today || x.NotificatieStatus == NotificatieStatus.Nieuw);
        }

        var model = new NotificatiesViewModel
        {
            AantalOngelezen = await dbQuery.CountAsync(x => x.NotificatieStatus == NotificatieStatus.Nieuw),
            Notificaties = await dbQuery.Select(x => new NotificatieListItemViewModel
            {
                Id = x.Id,
                Titel = x.Titel,
                Bericht = x.Bericht,
                NotificatieType = x.NotificatieType,
                Url = x.Url,
                NotificatieStatus = x.NotificatieStatus,
                Datum = x.Datum,
                MedewerkerId = x.MedewerkerId,
                OrganisatieId = x.Medewerker.OrganisatieId
            }).OrderByDescending(o => o.Datum)
                .ToListAsync()
        };

        return model;
    }
}