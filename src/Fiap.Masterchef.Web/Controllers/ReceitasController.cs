using Microsoft.AspNetCore.Mvc;

namespace Fiap.Masterchef.Web.Controllers
{
    public class ReceitasController : Controller
    {
        public IActionResult Index()
        {
            return View("_Vitrine");
        }
    }
}
