namespace Promeetec.EDMS.Domain.Models.Menu.MenuItem;

public class ReorderedMenuItem
{
    public Guid Id { get; set; }
    public Guid ParentId { get; set; }
    public int SortOrder { get; set; }

}