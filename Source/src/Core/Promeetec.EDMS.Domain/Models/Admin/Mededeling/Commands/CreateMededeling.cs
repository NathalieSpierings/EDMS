using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Admin.Mededeling.Commands;

public class CreateMededeling : CommandBase
{
    public string Content { get; set; }
}