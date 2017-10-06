using Fiap.Masterchef.Core.Commands;
using System;

namespace Fiap.Masterchef.Core.Application.Interfaces
{
    public interface IReceitaApplicationService
    {
        Receita CadastrarReceita(CadastrarReceitaCommand command);

        Receita AtualizarReceita(Guid receitaId, CadastrarReceitaCommand command);

        void AdicionarFavoritos(Guid receitaId);

        void RemoverFavoritos(Guid receitaId);
    }
}
