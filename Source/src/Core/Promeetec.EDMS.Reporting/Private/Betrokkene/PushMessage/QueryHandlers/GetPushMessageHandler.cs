using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.PushMessage;
using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.PushMessage.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.PushMessage.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.PushMessage.QueryHandlers;

public class GetPushMessageHandler : IQueryHandlerAsync<GetPushMessage, PushMessageViewModel>
{
    private readonly IPushMessageRepository _repository;
    private readonly IGroupRepository _groupRepository;

    public GetPushMessageHandler(IPushMessageRepository repository, IGroupRepository groupRepository)
    {
        _repository = repository;
        _groupRepository = groupRepository;
    }

    public async Task<PushMessageViewModel> HandleAsync(GetPushMessage query)
    {
        var model = await _repository.Query()
            .AsNoTracking()
            .Where(x => x.Id == query.PushMessageId)
            .OrderByDescending(o => o.Date)
            .Select(x => new PushMessageViewModel
            {
                Id = x.Id,
                Date = x.Date,
                Title = x.Title,
                Message = x.Message,
                Status = x.Status,
                GroupIds = x.GroupIds,
                Users = x.Users
            }).FirstOrDefaultAsync();

        if (!string.IsNullOrEmpty(model.GroupIds))
        {
            var ids = model.GroupIds.Split(',').Select(Guid.Parse).ToList();
            var groups = _groupRepository.GetGroups(ids);
            model.Groups = groups;
        }

        return model;
    }
}