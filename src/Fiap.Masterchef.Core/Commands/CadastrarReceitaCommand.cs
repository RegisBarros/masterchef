using System;

namespace Fiap.Masterchef.Core.Commands
{
    public class CadastrarReceitaCommand
    {
        public CadastrarReceitaCommand(string titulo, string descricao, string ingredientes, string preparo, string foto,
            byte[] fotoStream, string tags, int tempoPreparo, Guid categoriaId)
        {
            Titulo = titulo;
            Descricao = descricao;
            Ingredientes = ingredientes;
            Preparo = preparo;
            Foto = foto;
            FotoStream = fotoStream;
            Tags = tags;
            TempoPreparo = tempoPreparo;
            CategoriaId = categoriaId;
        }

        public string Titulo { get; private set; }

        public string Descricao { get; private set; }

        public string Ingredientes { get; private set; }

        public string Preparo { get; private set; }

        public byte[] FotoStream { get; private set; }

        public string Foto { get; private set; }

        public string Tags { get; private set; }

        /// <summary>
        /// Tempo de preparo em minutos
        /// </summary>
        public int TempoPreparo { get; private set; }

        public Guid CategoriaId { get; private set; }
    }
}
