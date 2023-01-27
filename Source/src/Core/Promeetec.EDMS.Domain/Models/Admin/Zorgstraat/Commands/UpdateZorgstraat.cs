using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Admin.Zorgstraat.Commands;

public class UpdateZorgstraat : CommandBase
{
    public string Naam { get; set; }
    public Shared.Status Status { get; set; }
}