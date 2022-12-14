using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht.Commands;

public class MarkAanleverberichtAsRead : CommandBase
{
    public DateTime? LaastGelezenOp { get; set; }
    public Guid LaatsteLezerId { get; set; }
}