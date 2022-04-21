namespace Promeetec.EDMS.Queries;

public interface IQueryProcessor
{
    Task<TResult> Process<TResult>(IQuery<TResult> query);
}