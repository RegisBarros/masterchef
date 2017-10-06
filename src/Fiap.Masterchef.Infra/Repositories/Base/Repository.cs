using Fiap.Masterchef.Core.Repositories.Base;
using Fiap.Masterchef.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Fiap.Masterchef.Infra.Repositories.Base
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        protected MasterchefContext _context;
        
        public void Adicionar(T entity)
        {
            _context.Set<T>().Add(entity);
            Salvar();
        }

        public void Atualizar(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            Salvar();
        }

        public void Excluir(Func<T, bool> predicate)
        {
            _context.Set<T>()
                .Where(predicate).ToList()
                .ForEach(d => _context.Set<T>().Remove(d));
            Salvar();
        }

        public IQueryable<T> Pesquisar()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> Pesquisar(Expression<Func<T, bool>> predicate)
        {
            return Pesquisar().Where(predicate).AsQueryable();
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public T ObterPorId(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
