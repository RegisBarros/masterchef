using Fiap.Masterchef.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Fiap.Masterchef.Core.Repositories
{
    public interface IReceitaRepository 
    {
        IEnumerable<VitrineViewModel> ObterFavoritas();

        IEnumerable<VitrineViewModel> ObterReceitas();

        IEnumerable<VitrineViewModel> ObterReceitas(string termo);
    }
}
