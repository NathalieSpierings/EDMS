namespace Promeetec.EDMS.Domain.Betrokkene.Memo.Commands;

public class CreateMemo : DomainCommand<Memo>
{
    public Guid MedewerkerId { get; set; }
    public DateTime Date { get; set; }
    public string Content { get; set; }
}