using Microsoft.AspNetCore.Http;
using System;

namespace Fiap.Masterchef.Core.Applicaton.ViewModels
{
    public class CadastroReceitaViewModel
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public Guid CategoriaId { get; set; }

        public string Tags { get; set; }

        public string Ingredientes { get; set; }

        public string Preparo { get; set; }

        public int TempoPreparo { get; set; }

        public IFormFile Foto { get; set; }
    }
}
