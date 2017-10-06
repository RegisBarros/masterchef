using Fiap.Masterchef.Core.Application.ViewModels;
using Fiap.Masterchef.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiap.Masterchef.Core.Repositories
{
    public interface IReceitaRepository : IRepository<Receita>
    {
        IEnumerable<VitrineViewModel> ObterFavoritas();

        IEnumerable<VitrineViewModel> ObterVitrineReceitas();

        Task<IEnumerable<ReceitaViewModel>> ObterReceitas();

        Task<ReceitaViewModel> ObterReceita(Guid id);

        IEnumerable<VitrineViewModel> ObterReceitas(string termo);
    }
}
