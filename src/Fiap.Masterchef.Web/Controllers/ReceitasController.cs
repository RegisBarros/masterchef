using Fiap.Masterchef.Core.Application.Interfaces;
using Fiap.Masterchef.Core.Applicaton.ViewModels;
using Fiap.Masterchef.Core.Commands;
using Fiap.Masterchef.Core.Repositories;
using Fiap.Masterchef.Infra.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Fiap.Masterchef.Web.Controllers
{
    public class ReceitasController : Controller
    {
        private readonly IReceitaRepository _receitaRepository;
        private readonly IReceitaApplicationService _receitaAppService;

        public ReceitasController(IReceitaRepository receitaRepository, IReceitaApplicationService receitaAppService)
        {
            _receitaRepository = receitaRepository;
            _receitaAppService = receitaAppService;
        }

        public IActionResult Index()
        {
            var receitas = _receitaRepository.ObterReceitas();

            return View("_Vitrine", receitas);
        }

        //[HttpPost, Route("receitas/cadastrar")]
        [HttpPost]
        public IActionResult CadastrarReceita(CadastroReceitaViewModel receita)
        {
            try
            {
                var httpPostedFile = Request.Form.Files.FirstOrDefault();

                var command = new CadastrarReceitaCommand(receita.Titulo, receita.Descricao, receita.Ingredientes,
                    receita.Preparo, httpPostedFile.FileName, httpPostedFile.GetDownloadBits(),
                    receita.Tags, receita.TempoPreparo, receita.CategoriaId);

                _receitaAppService.CadastrarReceita(command);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult AdicionarFavoritos(Guid receitaId)
        {
            try
            {
                _receitaAppService.AdicionarFavoritos(receitaId);
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
