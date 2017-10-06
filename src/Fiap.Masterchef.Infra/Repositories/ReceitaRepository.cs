using Fiap.Masterchef.Core;
using Fiap.Masterchef.Core.Application.ViewModels;
using Fiap.Masterchef.Core.Repositories;
using Fiap.Masterchef.Infra.Data.Contexts;
using Fiap.Masterchef.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Masterchef.Infra.Repositories
{
    public class ReceitaRepository : Repository<Receita>, IReceitaRepository
    {
        private const string _imagemPath = "http://fiapmasterchef.azurewebsites.net/images/";

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

        IEnumerable<VitrineViewModel> IReceitaRepository.ObterVitrineReceitas()
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

        async Task<ReceitaViewModel> IReceitaRepository.ObterReceita(Guid id)
        {
            var receitas = await (from r in _context.Receitas
                                  where r.Id == id
                                  select new ReceitaViewModel()
                                  {
                                      ReceitaId = r.Id,
                                      Titulo = r.Titulo,
                                      Descricao = r.Descricao,
                                      Favorito = r.Favorita,
                                      Foto = _imagemPath + r.Foto,
                                      TempoPreparo = r.TempoPreparo
                                  }).FirstOrDefaultAsync();

            return receitas;
        }

        async Task<IEnumerable<ReceitaViewModel>> IReceitaRepository.ObterReceitas()
        {
            var receitas = await (from r in _context.Receitas
                            select new ReceitaViewModel()
                            {
                                ReceitaId = r.Id,
                                Titulo = r.Titulo,
                                Descricao = r.Descricao,
                                Favorito = r.Favorita,
                                Foto = _imagemPath + r.Foto,
                                TempoPreparo = r.TempoPreparo
                            }).ToListAsync();

            return receitas;
        }
    }
}