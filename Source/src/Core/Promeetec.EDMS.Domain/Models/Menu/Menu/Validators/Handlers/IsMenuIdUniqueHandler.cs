using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Domain.Models.Menu.Menu.Validators.Rules;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Domain.Models.Menu.Menu.Validators.Handlers;

public class IsMenuIdUniqueHandler : IQueryHandler<IsMenuIdUnique, bool>
{
    private readonly IMenuRepository _repository;

    public IsMenuIdUniqueHandler(IMenuRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(IsMenuIdUnique query)
    {
        var any = query.Id != null 
            ? await _repository.Query().AnyAsync(x => x.Status != Status.Verwijderd && x.Id != query.Id) 
            : await _repository.Query().AnyAsync(x => x.Status != Status.Verwijderd);

        return !any;
    }
}