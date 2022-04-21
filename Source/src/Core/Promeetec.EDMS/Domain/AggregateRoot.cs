namespace Promeetec.EDMS.Domain;

public abstract class AggregateRoot : IAggregateRoot
{
    public Guid Id { get; set; }


    protected AggregateRoot()
    {
        Id = Guid.NewGuid();
    }

    protected AggregateRoot(Guid id)
    {
        if (id == Guid.Empty)
            id = Guid.NewGuid();

        Id = id;
    }
}
