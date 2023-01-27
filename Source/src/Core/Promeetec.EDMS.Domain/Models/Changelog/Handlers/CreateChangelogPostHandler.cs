using FluentValidation;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Changelog.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Changelog.Handlers;

public class CreateChangelogPostHandler : ICommandHandler<CreateChangelogPost>
{
    private readonly IChangelogRepository _repository;
    private readonly IValidator<CreateChangelogPost> _validator;

    public CreateChangelogPostHandler(IChangelogRepository repository,
        IValidator<CreateChangelogPost> validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(CreateChangelogPost command)
    {
        await _validator.ValidateCommand(command);

        var country = new Changelog(command);
        await _repository.AddAsync(country);

        return new IEvent[] { };
    }
}