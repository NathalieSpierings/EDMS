using Microsoft.AspNetCore.Mvc;

namespace Promeetec.EDMS.Web.Areas.Verbruiksmiddel.Controllers
{
    public class HomeController : Controller
    {
        [Area("Verbruiksmiddel")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
