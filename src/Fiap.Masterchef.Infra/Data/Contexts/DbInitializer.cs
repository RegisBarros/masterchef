using Fiap.Masterchef.Core;
using System.Linq;

namespace Fiap.Masterchef.Infra.Data.Contexts
{
    public static class DbInitializer
    {
        public static void Initialize(MasterchefContext context)
        {
            context.Database.EnsureCreated();

            if (context.Categorias.Any())
                return;

            var categorias = new Categoria[]
            {
                new Categoria("Aves", "Receitas de aves"),
                new Categoria("Bebidas", "Receitas de bebidas"),
                new Categoria("Bolos e Tortas", "Receitas de bolos e tortas"),
                new Categoria("Carnes", "Receitas de carnes"),
                new Categoria("Doces e Sobremesas", "Receitas de doces e sobremesas"),
                new Categoria("Lanches", "Receitas de lanches"),
                new Categoria("Massas", "Receitas de massas"),
                new Categoria("Saladas e Molhos", "Receitas de saladas e molhos"),
                new Categoria("Sopas", "Receitas de sopas")
            };

            context.Categorias.AddRange(categorias);

            context.SaveChanges();
        }
    }
}
