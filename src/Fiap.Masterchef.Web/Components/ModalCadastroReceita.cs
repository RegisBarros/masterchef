using Fiap.Masterchef.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Masterchef.Web.Components
{
    public class ModalCadastroReceita : ViewComponent
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public ModalCadastroReceita(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _categoriaRepository.ObterCategorias();

            return View(categorias);
        }
    }
}
