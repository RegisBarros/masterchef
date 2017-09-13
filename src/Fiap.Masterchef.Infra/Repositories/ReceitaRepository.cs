using Fiap.Masterchef.Core.Application.ViewModels;
using Fiap.Masterchef.Core.Repositories;
using System.Collections.Generic;

namespace Fiap.Masterchef.Infra.Repositories
{
    public class ReceitaRepository : IReceitaRepository
    {
        public IEnumerable<VitrineViewModel> ObterFavoritas()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<VitrineViewModel> ObterReceitas()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<VitrineViewModel> ObterReceitas(string termo)
        {
            throw new System.NotImplementedException();
        }
    }
}