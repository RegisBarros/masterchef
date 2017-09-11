using System;

namespace Fiap.Masterchef.Core
{
    public class Receita
    {
        public Guid Id { get; private set; }

        public string Titulo { get; private set; }

        public string Descricao { get; private set; }

        public string Ingredientes { get; private set; }

        public string Preparo { get; private set; }

        public string Foto { get; private set; }

        public string Tags { get; private set; }

        public bool Favorita { get; private set; }

        /// <summary>
        /// Tempo de preparo em minutos
        /// </summary>
        public int TempoPreparo { get; private set; }

        public Guid CategoriaId { get; private set; }

        public Categoria Categoria { get; private set; }

        public void DefinirFavorito()
        {
            Favorita = true;
        }

        public void RemoverFavorito()
        {
            Favorita = false;
        }

        public static Receita Criar(string titulo, string descricao, string ingredientes, string preparo, string foto,
            string tags, int tempoPreparo, Guid categoriaId)
        {
            return new Receita()
            {
                Id = Guid.NewGuid(),
                Titulo = titulo,
                Descricao = descricao,
                Ingredientes = ingredientes,
                Preparo = preparo,
                Foto = $"{Guid.NewGuid()}_{foto}",
                Tags = tags,
                TempoPreparo = tempoPreparo,
                CategoriaId = categoriaId
            };
        }
    }
}
