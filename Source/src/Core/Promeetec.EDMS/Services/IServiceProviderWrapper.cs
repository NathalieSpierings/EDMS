namespace Promeetec.EDMS.Services;

public interface IServiceProviderWrapper
{
    T? GetService<T>();
    IEnumerable<T> GetServices<T>();
}