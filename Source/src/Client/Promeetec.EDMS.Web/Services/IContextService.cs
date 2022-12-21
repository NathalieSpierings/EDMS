using Promeetec.EDMS.Reporting.Models.Public.Models;

namespace Promeetec.EDMS.Web.Services
{
    public interface IContextService
    {
        //Task<CurrentOrganisatieModel> CurrentOrganisatieAsync();
        Task<CurrentUserModel> CurrentUserAsync();
    }
}