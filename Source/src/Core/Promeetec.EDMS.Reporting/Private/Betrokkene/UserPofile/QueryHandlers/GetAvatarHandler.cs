using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.User.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.User.QueryHandlers;

public class GetAvatarHandler : IQueryHandler<GetAvatar, byte[]>
{
    private readonly IMedewerkerRepository _repository;

    public GetAvatarHandler(IMedewerkerRepository repository)
    {
        _repository = repository;
    }

    public byte[] Handle(GetAvatar query)
    {
        var dbQuery = _repository.GetById(query.MedewerkerId);
        return dbQuery?.Avatar;
    }
}