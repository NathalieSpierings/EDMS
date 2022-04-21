namespace Promeetec.EDMS.Queries
{
    public abstract class QueryBase<TResult> : IQuery<TResult>
    {
        public Guid OrganisatieId { get; set; }
    }
}
