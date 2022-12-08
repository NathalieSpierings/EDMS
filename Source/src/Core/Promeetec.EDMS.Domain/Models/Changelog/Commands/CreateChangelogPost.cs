using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Changelog.Commands;

public class CreateChangelogPost : CommandBase
{
    public DateTime Date { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    public ChangeLogType Type { get; set; }
    public string Tag { get; set; }
}