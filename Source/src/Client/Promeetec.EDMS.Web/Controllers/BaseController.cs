using Microsoft.AspNetCore.Mvc;

namespace Promeetec.EDMS.Web.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        protected BaseController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        //  protected async Task<CurrentOrganisatieModel> CurrentSite() => await _dispatcher.Get(new GetCurrentOrganisatie());
        //  protected async Task<CurrentUserModel> CurrentUser() => await _dispatcher.Get(new GetCurrentUser());
    }
}
