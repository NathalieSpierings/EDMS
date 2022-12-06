using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Admin.Zorgstraat.Commands;

public class UpdateZorgstraat : CommandBase
{
    public string Naam { get; set; }
    public Shared.Status Status { get; set; }
}