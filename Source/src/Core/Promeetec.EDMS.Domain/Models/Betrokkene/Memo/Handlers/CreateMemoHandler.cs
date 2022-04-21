using Promeetec.EDMS.Domain.Betrokkene.Memo.Commands;

namespace Promeetec.EDMS.Domain.Betrokkene.Memo.Handlers;

public class CreateMemoHandler : ICommandHandlerAsync<CreateMemo>
{
    private readonly IMemoRepository _repository;

    public CreateMemoHandler(IMemoRepository repository)
    {
        _repository = repository;
    }

    public async Task<CommandResponse> HandleAsync(CreateMemo command)
    {
        var memo = new Memo(command);
        await _repository.AddAsync(memo);

        return new CommandResponse
        {
            Events = memo.Events
        };
    }
}