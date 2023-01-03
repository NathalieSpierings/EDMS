using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Promeetec.EDMS.Reporting.Public.User.Models;
using Promeetec.EDMS.Reporting.Public.User.Queries;

namespace Promeetec.EDMS.Web.Controllers
{
    [Authorize]
    public abstract class BaseController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        protected BaseController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        
          protected async Task<CurrentUserModel> CurrentUser() => await _dispatcher.Get(new GetCurrentUser());
    }
}
