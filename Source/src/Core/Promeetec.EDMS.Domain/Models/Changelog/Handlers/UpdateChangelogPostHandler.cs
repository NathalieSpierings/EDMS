using System.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Changelog.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Changelog.Handlers;

public class UpdateChangelogPostHandler : ICommandHandler<UpdateChangelogPost>
{
    private readonly IChangelogRepository _repository;
    private readonly IValidator<UpdateChangelogPost> _validator;

    public UpdateChangelogPostHandler(IChangelogRepository repository,
        IValidator<UpdateChangelogPost> validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(UpdateChangelogPost command)
    {
        await _validator.ValidateCommand(command);

        var post = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id);
        if (post == null)
            throw new DataException($"Changelog post met Id {command.Id} niet gevonden.");

        post.Update(command);
        await _repository.UpdateAsync(post);

        return new IEvent[] { };
    }
}