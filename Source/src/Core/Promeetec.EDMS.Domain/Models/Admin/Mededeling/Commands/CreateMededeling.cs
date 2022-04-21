using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Admin.Mededeling.Commands;

public class CreateMededeling : CommandBase
{
    public Guid Id = Guid.NewGuid();

    public string Content { get; set; }
}