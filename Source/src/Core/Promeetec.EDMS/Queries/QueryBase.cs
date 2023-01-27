namespace Promeetec.EDMS.Portaal.Core.Queries
{
    public abstract class QueryBase<TResult> : IQuery<TResult>
    {
        public Guid OrganisatieId { get; set; }
    }
}
