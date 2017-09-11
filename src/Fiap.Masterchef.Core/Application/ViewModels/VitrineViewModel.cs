using System;
using System.Collections.Generic;

namespace Fiap.Masterchef.Core.Application.ViewModels
{
    public class VitrineViewModel
    {
        public VitrineViewModel()
        {
            Receitas = new List<ReceitaViewModel>();
        }

        public Guid CategoriaId { get; set; }

        public string Categoria { get; set; }

        public List<ReceitaViewModel> Receitas { get; set; }
    }
}
