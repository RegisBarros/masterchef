using Fiap.Masterchef.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Masterchef.Web.Controllers
{
    public class ReceitasController : Controller
    {
        private readonly IReceitaRepository _receitaRepository;

        public ReceitasController(IReceitaRepository receitaRepository)
        {
            _receitaRepository = receitaRepository;
        }

        public IActionResult Index()
        {
            var receitas = _receitaRepository.ObterReceitas();

            return View("_Vitrine", receitas);
        }
    }
}
