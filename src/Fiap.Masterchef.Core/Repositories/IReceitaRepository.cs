using Fiap.Masterchef.Core.Application.ViewModels;
using Fiap.Masterchef.Core.Repositories.Base;
using System.Collections.Generic;

namespace Fiap.Masterchef.Core.Repositories
{
    public interface IReceitaRepository : IRepository<Receita>
    {
        IEnumerable<VitrineViewModel> ObterFavoritas();

        IEnumerable<VitrineViewModel> ObterReceitas();

        IEnumerable<VitrineViewModel> ObterReceitas(string termo);
    }
}
