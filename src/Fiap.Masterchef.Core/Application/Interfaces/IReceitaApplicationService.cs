using Fiap.Masterchef.Core.Commands;
using System;

namespace Fiap.Masterchef.Core.Application.Interfaces
{
    public interface IReceitaApplicationService
    {
        void CadastrarReceita(CadastrarReceitaCommand command);

        void AdicionarFavoritos(Guid receitaId);

        void RemoverFavoritos(Guid receitaId);
    }
}
