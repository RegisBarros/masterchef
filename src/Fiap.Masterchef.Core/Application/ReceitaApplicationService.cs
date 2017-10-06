using Fiap.Masterchef.Core.Application.Interfaces;
using Fiap.Masterchef.Core.Commands;
using Fiap.Masterchef.Core.Repositories;
using Fiap.Masterchef.Core.Services;
using System;

namespace Fiap.Masterchef.Core.Applicaton
{
    public class ReceitaApplicationService : IReceitaApplicationService
    {
        private readonly IReceitaRepository _receitaRepository;
        private readonly IFotoService _fotoService;

        public ReceitaApplicationService(IReceitaRepository receitaRepository, IFotoService fotoService)
        {
            _receitaRepository = receitaRepository;
            _fotoService = fotoService;
        }

        public void AdicionarFavoritos(Guid receitaId)
        {
            var receita = _receitaRepository.ObterPorId(receitaId);

            if (receita == null)
                throw new InvalidOperationException($"Receita {receitaId} não foi encontrado");

            receita.DefinirFavorito();

            _receitaRepository.Atualizar(receita);
        }

        public void RemoverFavoritos(Guid receitaId)
        {
            var receita = _receitaRepository.ObterPorId(receitaId);

            if (receita == null)
                throw new InvalidOperationException($"Receita {receitaId} não foi encontrado");

            receita.RemoverFavorito();

            _receitaRepository.Atualizar(receita);
        }

        public Receita CadastrarReceita(CadastrarReceitaCommand command)
        {
            var receita = Receita.Criar(command.Titulo, command.Descricao, command.Ingredientes, command.Preparo, command.Foto,
                command.Tags, command.TempoPreparo, command.CategoriaId);

            _fotoService.Salvar(receita.Foto, command.FotoStream);

            _receitaRepository.Adicionar(receita);

            return receita;
        }

        public Receita AtualizarReceita(Guid receitaId, CadastrarReceitaCommand command)
        {
            var receita = _receitaRepository.ObterPorId(receitaId);

            if (receita == null)
                return null;

            receita.Atualizar(command.Titulo, command.Descricao, command.Ingredientes, command.Preparo, command.Foto,
               command.Tags, command.TempoPreparo, command.CategoriaId);

            _fotoService.Salvar(receita.Foto, command.FotoStream);

            _receitaRepository.Adicionar(receita);

            return receita;
        }
    }
}
