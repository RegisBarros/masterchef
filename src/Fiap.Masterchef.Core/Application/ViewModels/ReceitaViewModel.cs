using System;

namespace Fiap.Masterchef.Core.Application.ViewModels
{
    public class ReceitaViewModel
    {
        public Guid ReceitaId { get; set; }

        public string Foto { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        /// <summary>
        /// Tempo de preparo em minutos
        /// </summary>
        public int TempoPreparo { get; set; }

        public bool Favorito { get; set; }
    }
}
