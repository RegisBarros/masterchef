using Fiap.Masterchef.Core;
using Fiap.Masterchef.Core.Application.ViewModels;
using Fiap.Masterchef.Core.Repositories;
using Fiap.Masterchef.Infra.Data.Contexts;
using Fiap.Masterchef.Infra.Repositories.Base;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Masterchef.Infra.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(MasterchefContext context)
        {
            _context = context;
        }

        public IEnumerable<CategoriaViewModel> ObterCategorias()
        {
            var categorias = (from c in _context.Categorias
                              select new CategoriaViewModel()
                              {
                                  CategoriaId = c.Id,
                                  Nome = c.Titulo
                              }).ToList();

            return categorias;
        }
    }
}