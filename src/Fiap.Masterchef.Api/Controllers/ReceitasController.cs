using Fiap.Masterchef.Core.Application.Interfaces;
using Fiap.Masterchef.Core.Applicaton.ViewModels;
using Fiap.Masterchef.Core.Commands;
using Fiap.Masterchef.Core.Repositories;
using Fiap.Masterchef.Infra.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Masterchef.Api.Controllers
{
    [Route("api/[controller]")]
    public class ReceitasController : Controller
    {
        private readonly IReceitaRepository _receitaRepository;
        private readonly IReceitaApplicationService _receitaAppService;

        public ReceitasController(IReceitaRepository receitaRepository, IReceitaApplicationService receitaAppService)
        {
            _receitaRepository = receitaRepository;
            _receitaAppService = receitaAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var receitas = await _receitaRepository.ObterReceitas();

                if (receitas == null)
                    return NotFound();

                return Ok(receitas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var receita = await _receitaRepository.ObterReceita(id);

                if (receita == null)
                    return NotFound();

                return Ok(receita);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]CadastroReceitaViewModel cadastroReceita)
        {
            if (cadastroReceita == null)
                return NotFound();

            try
            {
                var httpPostedFile = Request.Form.Files.FirstOrDefault();

                var command = new CadastrarReceitaCommand(cadastroReceita.Titulo, cadastroReceita.Descricao, cadastroReceita.Ingredientes,
                   cadastroReceita.Preparo, httpPostedFile.FileName, httpPostedFile.GetDownloadBits(),
                   cadastroReceita.Tags, cadastroReceita.TempoPreparo, cadastroReceita.CategoriaId);

                var receita = _receitaAppService.CadastrarReceita(command);

                return CreatedAtRoute("Get", new { id = receita.Id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public IActionResult Put(Guid id, [FromBody]CadastroReceitaViewModel cadastroReceita)
        {
            if (cadastroReceita == null)
                return BadRequest();

            try
            {
                var httpPostedFile = Request.Form.Files.FirstOrDefault();

                var command = new CadastrarReceitaCommand(cadastroReceita.Titulo, cadastroReceita.Descricao, cadastroReceita.Ingredientes,
                   cadastroReceita.Preparo, httpPostedFile.FileName, httpPostedFile.GetDownloadBits(),
                   cadastroReceita.Tags, cadastroReceita.TempoPreparo, cadastroReceita.CategoriaId);

                var receita = _receitaAppService.AtualizarReceita(id, command);

                if (receita == null)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}:guid")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var receita = await _receitaRepository.ObterReceita(id);

                if (receita == null)
                    return NotFound();

                _receitaRepository.Excluir(r => r.Id == id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("favoritos/{id:guid}")]
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

        [HttpDelete("favoritos/{id:guid}")]
        public IActionResult RemoverFavoritos(Guid receitaId)
        {
            try
            {
                _receitaAppService.RemoverFavoritos(receitaId);
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
