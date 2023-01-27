using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanleverbericht.Commands;

public class MarkAanleverberichtAsRead : CommandBase
{
    public DateTime? LaastGelezenOp { get; set; }
    public Guid LaatsteLezerId { get; set; }
}