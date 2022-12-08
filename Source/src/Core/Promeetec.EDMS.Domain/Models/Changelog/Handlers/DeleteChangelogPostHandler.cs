using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Models.Changelog.Commands;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Changelog.Handlers;

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