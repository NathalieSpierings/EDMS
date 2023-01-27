using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Admin.Zorgstraat.Commands;

public class CreateZorgstraat : CommandBase
{
    public string Naam { get; set; }
}