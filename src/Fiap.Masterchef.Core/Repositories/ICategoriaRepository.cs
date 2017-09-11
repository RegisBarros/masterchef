using Fiap.Masterchef.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Fiap.Masterchef.Core.Repositories
{
    public interface ICategoriaRepository 
    {
        IEnumerable<CategoriaViewModel> ObterCategorias();
    }
}
