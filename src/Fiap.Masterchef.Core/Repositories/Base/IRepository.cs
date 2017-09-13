using System;
using System.Linq;
using System.Linq.Expressions;

namespace Fiap.Masterchef.Core.Repositories.Base
{
    public interface IRepository<T> : IDisposable where T : class
    {
        T ObterPorId(Guid id);
        IQueryable<T> Pesquisar(Expression<Func<T, bool>> predicate);
        IQueryable<T> Pesquisar();
        void Adicionar(T entity);
        void Atualizar(T entity);
        void Excluir(Func<T, bool> predicate);
        void Salvar();
    }
}
