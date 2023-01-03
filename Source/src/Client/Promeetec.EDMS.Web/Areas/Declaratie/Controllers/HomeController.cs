using Microsoft.AspNetCore.Mvc;

namespace Promeetec.EDMS.Web.Areas.Declaratie.Controllers
{
    public class HomeController : Controller
    {
        
        [Area("Declaratie")]
        public IActionResult Index()
        {
            return View();
        }
    }
}