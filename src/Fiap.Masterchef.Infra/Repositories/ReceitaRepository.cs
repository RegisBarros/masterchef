using Fiap.Masterchef.Core;
using Fiap.Masterchef.Core.Application.ViewModels;
using Fiap.Masterchef.Core.Repositories;
using Fiap.Masterchef.Infra.Data.Contexts;
using Fiap.Masterchef.Infra.Repositories.Base;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Masterchef.Infra.Repositories
{
    public class ReceitaRepository : Repository<Receita>, IReceitaRepository
    {
        public ReceitaRepository(MasterchefContext context)
        {
            _context = context;
        }

        IEnumerable<VitrineViewModel> IReceitaRepository.ObterFavoritas()
        {
            var vitrines = (from c in _context.Categorias
                            where c.Receitas.Any()
                            select new VitrineViewModel()
                            {
                                CategoriaId = c.Id,
                                Categoria = c.Titulo
                            }).ToList();

            foreach (var vitrine in vitrines)
            {
                var receitas = (from r in _context.Receitas
                                where r.CategoriaId == vitrine.CategoriaId
                                && r.Favorita
                                select new ReceitaViewModel()
                                {
                                    ReceitaId = r.Id,
                                    Titulo = r.Titulo,
                                    Descricao = r.Descricao,
                                    Foto = r.Foto,
                                    Favorito = r.Favorita,
                                    TempoPreparo = r.TempoPreparo
                                }).ToList();


                vitrine.Receitas.AddRange(receitas);
            }

            return vitrines.Where(v => v.Receitas.Any());
        }

        IEnumerable<VitrineViewModel> IReceitaRepository.ObterReceitas()
        {
            var vitrines = (from c in _context.Categorias
                            where c.Receitas.Any()
                            select new VitrineViewModel()
                            {
                                CategoriaId = c.Id,
                                Categoria = c.Titulo
                            }).ToList();

            foreach (var vitrine in vitrines)
            {
                var receitas = (from r in _context.Receitas
                                where r.CategoriaId == vitrine.CategoriaId
                                select new ReceitaViewModel()
                                {
                                    ReceitaId = r.Id,
                                    Titulo = r.Titulo,
                                    Descricao = r.Descricao,
                                    Foto = r.Foto,
                                    Favorito = r.Favorita,
                                    TempoPreparo = r.TempoPreparo
                                }).ToList();


                vitrine.Receitas.AddRange(receitas);
            }

            return vitrines.Where(v => v.Receitas.Any());
        }

        IEnumerable<VitrineViewModel> IReceitaRepository.ObterReceitas(string termo)
        {
            var vitrines = (from c in _context.Categorias
                            where c.Receitas.Any()
                            select new VitrineViewModel()
                            {
                                CategoriaId = c.Id,
                                Categoria = c.Titulo
                            }).ToList();

            foreach (var vitrine in vitrines)
            {
                var receitas = (from r in _context.Receitas
                                where r.CategoriaId == vitrine.CategoriaId
                                && (r.Titulo.Contains(termo) || r.Tags.Contains(termo))
                                select new ReceitaViewModel()
                                {
                                    ReceitaId = r.Id,
                                    Titulo = r.Titulo,
                                    Descricao = r.Descricao,
                                    Foto = r.Foto,
                                    Favorito = r.Favorita,
                                    TempoPreparo = r.TempoPreparo
                                }).ToList();


                vitrine.Receitas.AddRange(receitas);
            }

            return vitrines.Where(v => v.Receitas.Any());
        }
    }
}