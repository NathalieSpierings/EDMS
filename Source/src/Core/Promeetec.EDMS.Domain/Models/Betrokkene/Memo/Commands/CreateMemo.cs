using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Memo.Commands;

public class CreateMemo : CommandBase
{
    public Guid MedewerkerId { get; set; }
    public DateTime Date { get; set; }
    public string Content { get; set; }
}