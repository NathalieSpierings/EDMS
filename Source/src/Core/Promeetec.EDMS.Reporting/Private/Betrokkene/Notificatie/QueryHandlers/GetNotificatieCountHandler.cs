using System.Linq;
using Promeetec.EDMS.Domain.Models.Betrokkene.Notificatie;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Notificatie.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Notificatie.QueryHandlers;

public class GetNotificatieCountHandler : IQueryHandler<GetNotificatieCount, int>
{
    private readonly INotificatieRepository _repository;
    public GetNotificatieCountHandler(INotificatieRepository repository)
    {
        _repository = repository;
    }

    public int Handle(GetNotificatieCount query)
    {
        var total = _repository.Query().Count(x => x.MedewerkerId == query.MedewerkerId && x.NotificatieStatus != NotificatieStatus.Gelezen);
        return total;
    }
}