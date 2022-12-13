using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Domain.Models.Shared;

namespace Promeetec.EDMS.Data.Repositories;

public class GroupRepository : Repository<Group>, IGroupRepository
{
    public GroupRepository(EDMSDbContext context) : base(context)
    {
    }


    /// <inheritdoc />
    public IEnumerable<Group> GetGroups(IEnumerable<Guid> groupIds)
    {
        var result = new List<Group>();
        var dbEntities = Query()
            .Where(x => groupIds.Contains(x.Id));

        result.AddRange(dbEntities);
        return result;
    }

    /// <inheritdoc />
    public async Task<Group?> GetGroupByIdAsync(Guid id, bool includeDeletes = false)
    {
        var dbEntity = await Query()
            .FirstOrDefaultAsync(x => includeDeletes ? x.Id == id : x.Id == id && x.Status != Status.Verwijderd);
        return dbEntity;
    }

    /// <inheritdoc />
    public async Task<List<Group>> GetGroupsForUser(Guid userId)
    {
        var dbQuery = await Query()
            .Where(x => x.Users.Select(y => y.UserId).Contains(userId))
            .ToListAsync();

        return dbQuery;
    }

    public async Task<List<Group>> RemoveUserFromGroup(Guid userId)
    {
        var dbQuery = await Query()
            .Where(x => x.Users.Select(y => y.UserId).Contains(userId))
            .ToListAsync();

        return dbQuery;
    }
}