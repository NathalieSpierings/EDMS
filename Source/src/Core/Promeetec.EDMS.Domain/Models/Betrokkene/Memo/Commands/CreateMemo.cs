using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Memo.Commands;

public class CreateMemo : CommandBase
{
    public Guid MedewerkerId { get; set; }
    public DateTime Date { get; set; }
    public string Content { get; set; }
}