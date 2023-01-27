using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Changelog.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Changelog.Handlers;

public class DeleteChangelogPostHandler : ICommandHandler<DeleteChangelogPost>
{
    private readonly IChangelogRepository _repository;

    public DeleteChangelogPostHandler(IChangelogRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<IEvent>> Handle(DeleteChangelogPost command)
    {
        var post = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id);
        if (post == null)
            throw new DataException($"Changelog post met Id {command.Id} niet gevonden.");
        await _repository.RemoveAsync(post);

        return new IEvent[] { };
    }
}