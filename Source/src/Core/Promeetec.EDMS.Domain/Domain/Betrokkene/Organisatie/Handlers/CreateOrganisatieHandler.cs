using FluentValidation;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Domain.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Domain.Betrokkene.Organisatie.Handlers;

public class CreateOrganisatieHandler : ICommandHandler<CreateOrganisatie>
{
    private readonly EDMSDbContext _dbContext;
    private readonly IValidator<CreateOrganisatie> _validator;
    private readonly ICacheManager _cacheManager;

    public async Task<IEnumerable<IEvent>> Handle(CreateOrganisatie command)
    {
        throw new NotImplementedException();
    }
}