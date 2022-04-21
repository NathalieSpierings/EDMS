using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Admin.Mededeling.Commands;

public class UpdateMededeling : CommandBase
{
    public string Content { get; set; }
}