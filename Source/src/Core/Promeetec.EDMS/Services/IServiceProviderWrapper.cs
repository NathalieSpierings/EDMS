namespace Promeetec.EDMS.Portaal.Core.Services;

public interface IServiceProviderWrapper
{
    T? GetService<T>();
    IEnumerable<T> GetServices<T>();
}