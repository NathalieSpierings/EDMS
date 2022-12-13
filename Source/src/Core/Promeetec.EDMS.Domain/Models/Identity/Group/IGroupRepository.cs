namespace Promeetec.EDMS.Domain.Models.Identity.Group;

public interface IGroupRepository : IRepository<Group>
{
    /// <summary>
    /// Gets the groups.
    /// </summary>
    /// <param name="groupIds">The group ids.</param>
    /// <returns></returns>
    IEnumerable<Group> GetGroups(IEnumerable<Guid> groupIds);

    /// <summary>
    /// Gets the group by identifier asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="includeDeletes">if set to <c>true</c> [include deletes].</param>
    /// <returns></returns>
    Task<Group?> GetGroupByIdAsync(Guid id, bool includeDeletes = false);

    /// <summary>
    /// Gets the groups for the given user.
    /// </summary>
    /// <param name="userId">The user identifier.</param>
    /// <returns></returns>
    Task<List<Group>> GetGroupsForUser(Guid userId);
}