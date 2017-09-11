using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Masterchef.Core
{
    public class Categoria
    {
        public Categoria(string titulo, string descricao)
        {
            Id = Guid.NewGuid();
            Titulo = titulo;
            Descricao = descricao;
        }

        public Guid Id { get; private set; }

        public string Titulo { get; private set; }

        public string Descricao { get; private set; }

        public ICollection<Receita> Receitas { get; private set; }
    }
}
