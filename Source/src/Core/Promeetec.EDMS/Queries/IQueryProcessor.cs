namespace Promeetec.EDMS.Portaal.Core.Queries;

public interface IQueryProcessor
{
    Task<TResult> Process<TResult>(IQuery<TResult> query);
}