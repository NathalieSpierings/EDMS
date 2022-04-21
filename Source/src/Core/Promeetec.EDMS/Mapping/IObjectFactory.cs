namespace Promeetec.EDMS.Mapping;

public interface IObjectFactory
{
    /// <summary>
    /// Creates the concrete object.
    /// </summary>
    /// <param name="obj">The object.</param>
    /// <returns></returns>
    dynamic CreateConcreteObject(object obj);
}
