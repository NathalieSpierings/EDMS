using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Domain.Models.Menu.Menu.Validators.Rules;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Domain.Models.Menu.Menu.Validators.Handlers;

public class IsMenuNameUniqueHandler : IQueryHandler<IsMenuNameUnique, bool>
{
    private readonly IMenuRepository _repository;

    public IsMenuNameUniqueHandler(IMenuRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(IsMenuNameUnique query)
    {
        var menu = await _repository.Query().FirstOrDefaultAsync(x => x.Name == query.Name);
        return menu == null || menu.Status == Status.Verwijderd;
    }
}