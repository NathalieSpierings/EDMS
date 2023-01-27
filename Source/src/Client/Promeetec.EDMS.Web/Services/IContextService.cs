using Promeetec.EDMS.Portaal.Reporting.Public.User.Models;

namespace Promeetec.EDMS.Web.Services
{
    public interface IContextService
    {
        Task<CurrentUserModel> CurrentUserAsync();
    }
}