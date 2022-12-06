using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Admin.Zorgstraat.Commands;

public class CreateZorgstraat : CommandBase
{
    public string Naam { get; set; }
}